using DataSmart.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSmart.Models;
using DataSmart.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.Entity.Migrations;

namespace DataSmart.ViewModels
{
    public class EmployeeVM : BaseModel
    {
        #region Properties
        //public Employee Employee { get; set; }
        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; RaisePropertyChanged("Employee"); }
        }

        private Employee _SelectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value; 
                RaisePropertyChanged("SelectedEmployee");
                if(SelectedEmployee != null)
                {
                    Employee = Misc.DeepCopy(SelectedEmployee) as Employee; 
                    RaisePropertyChanged("Employee");
                }
            }
        }

        public ObservableCollection<Employee> EmployeeList { get; set; }
        public EmployeeCommand EmployeeCmd { get; set; }
        #endregion

        #region Constructor
        public EmployeeVM()
        {
            Employee = new Employee();
            
            EmployeeList = new ObservableCollection<Employee>();
            FillEmployeeGrid();

            EmployeeCmd = new EmployeeCommand(this);
        }
        #endregion

        #region Buttons Actions
        public void AddNewEmployee()
        {
            using (var db = new DataSmartDBContext())
            {
                if (db.Employee.Any(o => o.EmployeeSIN == Employee.EmployeeSIN))
                {
                    MessageBox.Show("Employé deja existant dans la base de donnée. Aucun changement effectué", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    db.Employee.Add(Employee);
                    db.SaveChanges();
                    MessageBox.Show("Nouvel employé sauvegardé dans la base données avec succès", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void UpdateEmployee()
        {
            using (var db = new DataSmartDBContext())
            {
                var employeeToUpdate = db.Employee.Find(SelectedEmployee.EmployeeId);

                // Check wether the new value of EmployeeSIN is identical to an existing Employee EmployeeSIN since this property value should be unique
                if (db.Employee.Any(o => o.EmployeeId != Employee.EmployeeId & o.EmployeeSIN == Employee.EmployeeSIN))
                {
                    MessageBox.Show("Il existe deja un employé avec le meme ID dans la base de donnée", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                } 
                else // Else apply updates to the selected employee
                {
                    // Show a dialog box to confirm the action. if result is Yes then apply changes otherwise do nothing
                    var result = MessageBox.Show("Vous êtes sur le point de modifier les informations de la ligne séctionnée avec les informations affichées. " +
                        "Voulez vous poursuivre la modification?", "DataSmart Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if(result == MessageBoxResult.Yes)
                    {
                        // Update the selected entity property values with th new ones
                        db.Entry(employeeToUpdate).CurrentValues.SetValues(Employee);
                        db.SaveChanges();   // Save changes to the database
                        MessageBox.Show("Employé Mis À Jour", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        public void DeleteEmployee()
        {
            using (var db = new DataSmartDBContext())
            {
                var employeeToDelete = db.Employee.Find(SelectedEmployee.EmployeeId);
                if(employeeToDelete != null)
                {
                    var result = MessageBox.Show("Êtes vous sûre de supprimer définitivement Cet Employé?", "DataSmart Info",MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if(result == MessageBoxResult.Yes)
                    {
                        db.Employee.Remove(employeeToDelete);
                        db.SaveChanges();
                        MessageBox.Show("Employé Supprimé de la base de données avec succès!", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        #endregion

        #region General Methods
        public void FillEmployeeGrid()
        {
            if(EmployeeList.Count() > 0)
            {
                EmployeeList.Clear();
            }
            using (var db = new DataSmartDBContext())
            {
                var emp = db.Employee.ToList();

                if (emp != null)
                {
                    foreach (var d in emp)
                    {
                        EmployeeList.Add(d);
                    }
                }
                
            }

        }
        #endregion
    }
}
