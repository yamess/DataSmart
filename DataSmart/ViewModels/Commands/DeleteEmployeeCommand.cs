using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSmart.ViewModels.Commands
{
    public class DeleteEmployeeCommand : ICommand
    {
        #region
        public EmployeeVM EmployeeVM { get; set; }
        #endregion

        #region Event Handler
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Initialisation
        public DeleteEmployeeCommand(EmployeeVM vm)
        {
            EmployeeVM = vm;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return (EmployeeVM.SelectedEmployee != null);
        }

        public void Execute(object parameter)
        {
            EmployeeVM.DeleteEmployee();
        }
        #endregion
    }
}
