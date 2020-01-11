using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmart.Helpers;
using DataSmart.Models;
using DataSmart.ViewModels.Commands;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AutoMapper;

namespace DataSmart.ViewModels
{
    public class ProductVM:BaseModel
    {
        #region Properties

        private Product _product;
        public Product Product
        {
            get { return _product; }
            set { _product = value; RaisePropertyChanged("Product"); }
        }

        private Product _SelectedProduct;
        public Product SelectedProduct
        {
            get { return _SelectedProduct; }
            set
            {
                _SelectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
                if(SelectedProduct != null)
                {
                    Product = Misc.DeepCopy(SelectedProduct) as Product;
                    RaisePropertyChanged("Product");
                }
            }
        }

        //public ProductStructure ProductStructure { get; set; }

        public ObservableCollection<Product> ProductList { get; set; }

        private IList<string> _categoryList;
        public IList<string> CategoryList
        {
            get { return _categoryList; }
            set { _categoryList = value; RaisePropertyChanged("CategoryList"); }
        }

        private IList<string> _subCategoryList;
        public IList<string> SubCategoryList
        {
            get 
            {
                return _subCategoryList;
            }
            set { _subCategoryList = value; RaisePropertyChanged("SubCategoryList"); }
        }

        public ProductCommand ProductCmd { get; set; }

        #endregion

        #region Constructor of the class
        public ProductVM()
        {

            Product = new Product()
            {
                DateOfRecord = DateTime.Now,
                DateOfPurchase = DateTime.Now.ToShortDateString()
            };
            //{
            //    ProductName = "Samsung Galaxy S9",
            //    ProductCategory_1 = CategoryList[0],
            //    ProductCategory_2 = SubCategoryList[0],
            //    ,
            //    DateOfPurchase = DateTime.Now.ToShortDateString(),
            //    UnitPurchasePrice = 600000,
            //    UnitSalePrice = 800000,
            //    MaxDiscount = 50000,
            //    Quantity = 30,
            //    EmployeeId = 25
            //};

            ProductList = new ObservableCollection<Product>();

            FillProductGrid(); // Retrieve data from the database

            CategoryList = new List<string>();
            SubCategoryList = new List<string>();
            
            GetProductStructure();

            ProductCmd = new ProductCommand(this);

        }
        #endregion

        #region Buttons Actions
        /// <summary>
        /// Method to Save new entity of Product
        /// </summary>
        public void AddNewProduct()
        {
            using (var db = new DataSmartDBContext())
            {
                if (db.Produits.Any(o => o.ProductName == Product.ProductName & o.ProductCategory_1 == Product.ProductCategory_1 & o.ProductCategory_2 == Product.ProductCategory_2))
                {
                    MessageBox.Show("Il existe déja un produit avec le meme nom dans la base de données. Veuillez vérifier de nouveau les informations saisies." +
                        "Aucun Changement affectué.", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    Product.DateOfRecord = DateTime.Now;
                    db.Produits.Add(Product);
                    db.SaveChanges();
                    MessageBox.Show("Nouveau produit sauvegardé dans la base de données avec succès", "DataSmart", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        ///  Method to update an Existing Entity of Product
        /// </summary>
        public void UpdateProduct()
        {
            using (var db = new DataSmartDBContext())
            {
                var productToUpdate = db.Produits.Find(SelectedProduct.ProductId);
                if(db.Produits.Any(o => o.ProductId != Product.ProductId & o.ProductName == Product.ProductName))
                {
                    MessageBox.Show("Il existe deja un autre produit avec le meme nom dans la base de donnée", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var result = MessageBox.Show("Vous êtes sur le point de modifier les informations de la ligne séctionnée avec les informations affichées. " +
                        "Voulez vous poursuivre la modification?", "DataSmart Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if(result == MessageBoxResult.Yes)
                    {
                        db.Entry(productToUpdate).CurrentValues.SetValues(Product);
                        db.SaveChanges();
                        MessageBox.Show("Produit Mis à Jour!", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        /// <summary>
        /// Method to Delete Existing Enity of Product
        /// </summary>
        public void DeleteProduct()
        {
            using (var db = new DataSmartDBContext())
            {
                var productToDelete = db.Produits.Find(SelectedProduct.ProductId);

                if(productToDelete != null)
                {
                    var result = MessageBox.Show("Êtes vous sûre de supprimer définitivement Cet Employé?", "DataSmart Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    
                    if(result == MessageBoxResult.Yes)
                    {
                        db.Produits.Remove(productToDelete);
                        db.SaveChanges();
                        MessageBox.Show("Produit supprimé de la base de données avec succès!", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        #endregion

        #region General Methods

        // Method to fill the datagrid
        public void FillProductGrid()
        {
            if(ProductList.Count() > 0)
            {
                ProductList.Clear();
            }
            using (var db = new DataSmartDBContext())
            {
                var prod = db.Produits.ToList();
                
                if(prod != null)
                {
                    foreach (var d in prod)
                    {
                        ProductList.Add(d);
                    }
                }
            }
        }

        public void SaveNewProductStructure()
        {
            using (var db = new DataSmartDBContext())
            {
                if (db.ProductStructure.Any(o => o.Category_1 == Product.ProductCategory_1 & o.Category_2 == Product.ProductCategory_2))
                {
                    return;
                } 
                else
                {
                    ProductStructure Structure = new ProductStructure()
                    {
                        Category_1 = Product.ProductCategory_1,
                        Category_2 = Product.ProductCategory_2
                    };
                    db.ProductStructure.Add(Structure);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to Get the Product Structures(Hierachie) to fill the Category and Subcategory Combobox
        /// </summary>
        public void GetProductStructure()
        {
            if(CategoryList.Count() > 0)
            {
                CategoryList.Clear();
            }

            if(SubCategoryList.Count() > 0)
            {
                SubCategoryList.Clear();
            }

            using (var db = new DataSmartDBContext())
            {
                var structure = db.ProductStructure.ToList();

                if(structure != null)
                {
                    foreach (var d in structure)
                    {
                        CategoryList.Add(d.Category_1);
                        SubCategoryList.Add(d.Category_2);
                    }
                    CategoryList = CategoryList.Distinct().ToList();
                    SubCategoryList = SubCategoryList.Distinct().ToList();
                }
            }
        }

        #endregion
    }
}
