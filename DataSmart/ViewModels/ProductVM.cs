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
        public Product Product { get; set; }
        public Employee Employee { get; set; }
        public Product SelectedProduct { get; set; }

        private ProductStructure _SelectedProductStructure;
        public ProductStructure SelectedProductStructure
        {
            get { return _SelectedProductStructure; }
            set { _SelectedProductStructure = value; RaisePropertyChanged("SelectedProductStructure"); RaisePropertyChanged("Product.ProductCategory_1"); }
        }

        public NewProductCommand AddNewProductCmd { get; set; }
        public UpdateProductCommand UpdateProductCmd { get; set; }
        public DeleteProductCommand DeleteProductCmd { get; set; }
        public ProductStructure ProductStructure { get; set; }

        private int _NumberOfRecord;
        public int NumberOfRecord
        {
            get { return _NumberOfRecord; }
            set { _NumberOfRecord = value; RaisePropertyChanged("NumberOfRecord"); }
        }



        public ObservableCollection<Product> ProductList { get; set; }
        //public ObservableCollection<ProductStructure> ProductStructureList { get; set; }

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

        #endregion

        #region Initialization of the class
        public ProductVM()
        {
            CategoryList = new List<string>();
            SubCategoryList = new List<string>();
            SelectedProductStructure = new ProductStructure();
            ProductList = new ObservableCollection<Product>();

            GetProductStructure();

            Product = new Product()
            {
                ProductName = "Samsung Galaxy S9",
                ProductCategory_1 = CategoryList[0],
                ProductCategory_2 = SubCategoryList[0],
                DateOfRecord = DateTime.Now,
                DateOfPurchase = DateTime.Now.ToShortDateString(),
                UnitPurchasePrice = 600000,
                UnitSalePrice = 800000,
                MaxDiscount = 50000,
                Quantity = 30,
                EmployeeId = 25
            };

            FillDataGrid(); // Retrieve data from the database
            

            AddNewProductCmd = new NewProductCommand(this);
            UpdateProductCmd = new UpdateProductCommand(this);
            DeleteProductCmd = new DeleteProductCommand(this);
        }
        #endregion

        #region Methods

        // Method to fill the datagrid
        public void FillDataGrid()
        {
            using (var db = new DataSmartDBContext())
            {
                var prod = db.Produits.ToList();
                foreach (var d in prod)
                {
                    ProductList.Add(d);
                }
            };
            NumberOfRecord = ProductList.Count();
        }

        public void SaveNewProductStructure(string Category,string SubCategory)
        {
            using (var db = new DataSmartDBContext())
            {
                if (db.ProductStructure.Any(o => o.Category_1 == Category & o.Category_2 == SubCategory))
                {
                    return;
                } else
                {
                    ProductStructure Structure = new ProductStructure()
                    {
                        Category_1 = Category,
                        Category_2 = SubCategory
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
            using (var db = new DataSmartDBContext())
            {
                var structure = (from data in db.ProductStructure select data);

                foreach(var d in structure)
                {
                    CategoryList.Add(d.Category_1);
                    SubCategoryList.Add(d.Category_2);
                }
            }
            CategoryList = CategoryList.Distinct().ToList();
            SubCategoryList = SubCategoryList.Distinct().ToList();
        }

        /// <summary>
        /// Method to Save new entity of Product
        /// </summary>
        public void AddNewProduct()
        {
            if (CheckDuplicateProduct())
            {
                return;
            }
            using (var db = new DataSmartDBContext())
            {
                db.Produits.Add(Product);
                db.SaveChanges();
                //MessageBox.Show("Produit Sauvegardé","DataSmart", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ProductList.Clear();
            FillDataGrid();

            SaveNewProductStructure(Product.ProductCategory_1,Product.ProductCategory_2);

            CategoryList.Clear();
            SubCategoryList.Clear();
            GetProductStructure();
            MessageBox.Show("Produit Sauvegardé", "DataSmart", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Method to Delete Existing Enity of Product
        /// </summary>
        public void DeleteProduct()
        {
            using (var db = new DataSmartDBContext())
            {
                var productToUpdate = db.Produits.Find(SelectedProduct.ProductId);
                db.Produits.Remove(productToUpdate);
                db.SaveChanges();
                MessageBox.Show("Produit Supprimé!", "DataSmart", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ProductList.Clear();
            FillDataGrid();

            CategoryList.Clear();
            SubCategoryList.Clear();
            GetProductStructure();
        }

        /// <summary>
        ///  Method to update an Existing Entity of Product
        /// </summary>
        public void UpdateProduct()
        {
            using (var db = new DataSmartDBContext())
            {
                var productToUpdate = db.Produits.Find(SelectedProduct.ProductId);
                db.Entry(productToUpdate).CurrentValues.SetValues(Product);
                db.SaveChanges();
                MessageBox.Show("Produit Mis à Jour!", "DataSmart", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            ProductList.Clear();
            FillDataGrid();

            CategoryList.Clear();
            SubCategoryList.Clear();
            GetProductStructure();
        }

        /// <summary>
        /// Method to check if the there is a duplicate record
        /// </summary>
        /// <returns>Boolean: True if there is duplicate and false if else</returns>
        public bool CheckDuplicateProduct()
        {
            //var result = false;
            using (var db = new DataSmartDBContext())
            {
                if (db.Produits.Any(o => o.ProductName == Product.ProductName && o.ProductCategory_1 == Product.ProductCategory_1 && o.ProductCategory_2 == Product.ProductCategory_2))
                {
                    MessageBox.Show("Produit Existant Dans la Base de Donnée", "Duplicat De Produit", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return true;
                }
                return false;
            }
        }


        #endregion
    }
}
