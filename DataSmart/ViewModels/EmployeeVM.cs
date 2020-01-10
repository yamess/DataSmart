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
                _SelectedEmployee = value; RaisePropertyChanged("SelectedEmployee");
                if(SelectedEmployee != null)
                {
                    Employee = SelectedEmployee; RaisePropertyChanged("Employee");
                }
            }
        }

        public ObservableCollection<Employee> EmployeeList { get; set; }
        public EmployeeCommand EmployeeCmd { get; set; }
        #endregion

        #region Initialisation
        public EmployeeVM()
        {
            Employee = new Employee()
            {
                EmployeeSIN = "S23G34D30",
                FirstName = "Kary",
                LastName = "Yamess",
                Email = "kary.yamess@karyamess.ca",
                Phone = "418-233-9800",
                Address = "56 George Street, Toronto, Canada",
                Position = "Data Scientist",
                Salary = 120000,
                DateOfHire = DateTime.Now.ToShortDateString(),
                DateOfBirth = DateTime.Now.ToShortDateString(),
            };
            
            EmployeeList = new ObservableCollection<Employee>();
            FillEmployeeGrid();

            EmployeeCmd = new EmployeeCommand(this);
        }
        #endregion

        #region Methods
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
                    MessageBox.Show("Nouvel Employé Sauvegardé", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void UpdateEmployee()
        {
            using (var db = new DataSmartDBContext())
            {
                var employeeToUpdate = db.Employee.Find(SelectedEmployee.EmployeeId);

                if (db.Employee.Any(o => o.EmployeeId != Employee.EmployeeId & o.EmployeeSIN == Employee.EmployeeSIN))
                {
                    MessageBox.Show("Il existe deja un employé avec le meme ID dans la base de donnée", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                } 
                else
                {
                    Employee.EmployeeId = employeeToUpdate.EmployeeId;
                    db.Entry(employeeToUpdate).CurrentValues.SetValues(Employee);
                    //db.Employee.AddOrUpdate(Employee);
                    db.SaveChanges();
                    MessageBox.Show("Employé Mis À Jour", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
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
                        MessageBox.Show("Employé Supprimé de la base de données", "DataSmart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

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

        public void NewWindow()
        {

        }
        #endregion
    }
}
