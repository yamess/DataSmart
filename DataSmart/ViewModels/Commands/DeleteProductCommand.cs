using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSmart.ViewModels.Commands
{
    public class DeleteProductCommand : ICommand
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
        public DeleteProductCommand(ProductVM vm)
        {
            ProductVM = vm;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return (ProductVM.SelectedProduct != null);
        }

        public void Execute(object parameter)
        {
            ProductVM.DeleteProduct();
        }
        #endregion
    }
}
