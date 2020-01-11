using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataSmart.ViewModels;

namespace DataSmart.ViewModels.Commands
{
    public class ProductCommand : ICommand
    {
        public ProductVM ProductVM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #region the class Constractor
        public ProductCommand(ProductVM vm)
        {
            ProductVM = vm;
        }
        #endregion

        public bool CanExecute(object parameter)
        {
            string param = parameter as string;
            if(param == "Add")
            {
                if(string.IsNullOrWhiteSpace(ProductVM.Product.ProductName) | string.IsNullOrWhiteSpace(ProductVM.Product.ProductCategory_1))
                {
                    return false;
                }
                return true;
            }
            else if(param == "Delete" | param == "Update")
            {
                return (ProductVM.SelectedProduct != null);
            }
            return false;
        }

        public void Execute(object parameter)
        {
            string param = parameter as string;
            switch (param)
            {
                case "Add":
                    ProductVM.AddNewProduct();
                    ProductVM.FillProductGrid();
                    ProductVM.SaveNewProductStructure();
                    ProductVM.GetProductStructure();
                    break;
                case "Delete":
                    ProductVM.DeleteProduct();
                    ProductVM.FillProductGrid();
                    break;
                case "Update":
                    ProductVM.UpdateProduct();
                    ProductVM.SaveNewProductStructure();
                    ProductVM.FillProductGrid();
                    ProductVM.GetProductStructure();
                    break;
            }
        }
    }
}
