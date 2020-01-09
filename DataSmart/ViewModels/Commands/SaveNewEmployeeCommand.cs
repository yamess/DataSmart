using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSmart.ViewModels.Commands
{
    public class SaveNewEmployeeCommand : ICommand
    {
        #region Properties
        public EmployeeVM EmployeeVM { get; set; }
        #endregion

        #region EventHandler
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Initialisation
        public SaveNewEmployeeCommand(EmployeeVM vm)
        {
            EmployeeVM = vm;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
           if(string.IsNullOrWhiteSpace(EmployeeVM.Employee.EmployeeSIN) | string.IsNullOrWhiteSpace(EmployeeVM.Employee.LastName))
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            EmployeeVM.AddNewEmployee();
        }
        #endregion
    }
}
