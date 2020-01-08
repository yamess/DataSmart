using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSmart.ViewModels.Commands
{
    public class NewProductCommand : ICommand
    {
        #region Envent Handler
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Properties
        public ProductVM ProductVM { get; set; }
        #endregion

        #region Initialization of the Class
        public NewProductCommand(ProductVM vm)
        {
            ProductVM = vm;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            string param = parameter as string;
            if (string.IsNullOrWhiteSpace(param))
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            ProductVM.AddNewProduct();
        }
        #endregion
    }
}
