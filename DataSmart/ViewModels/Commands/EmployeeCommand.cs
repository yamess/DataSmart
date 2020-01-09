using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSmart.ViewModels.Commands
{
    public class EmployeeCommand: ICommand
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
        public EmployeeCommand(EmployeeVM vm)
        {
            EmployeeVM = vm;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            string param = parameter as string;
            if (param == "Add")
            {
                if (string.IsNullOrWhiteSpace(EmployeeVM.Employee.EmployeeSIN) | string.IsNullOrWhiteSpace(EmployeeVM.Employee.LastName))
                {
                    return false;
                }
                return true;
            }
            else if (param == "Delete" | param == "Update")
            {
                return (EmployeeVM.SelectedEmployee != null);
            }
            return false;
        }

        public void Execute(object parameter)
        {
            string action = parameter as string;
            switch (action)
            {
                case "Add":
                    EmployeeVM.AddNewEmployee();
                    EmployeeVM.FillEmployeeGrid();
                    break;
                case "Delete":
                    EmployeeVM.DeleteEmployee();
                    EmployeeVM.FillEmployeeGrid();
                    break;
                case "Update":
                    EmployeeVM.UpdateEmployee();
                    EmployeeVM.FillEmployeeGrid();
                    break;
            }
        }
        #endregion
    }
}
