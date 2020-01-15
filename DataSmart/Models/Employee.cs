using DataSmart.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSmart.Models
{
    public class Employee : BaseModel
    {
        [Key]
        public int EmployeeId { get; set; }

        private string _EmployeeSIN;

        //[ForeignKey("UserId")]
        //public int UserId { get; set; }

        [Index(IsUnique = true)]
        public string EmployeeSIN
        {
            get { return _EmployeeSIN; }
            set { _EmployeeSIN = value; RaisePropertyChanged("EmployeeSIN");}
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; RaisePropertyChanged("FirstName"); }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; RaisePropertyChanged("LastName"); }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; RaisePropertyChanged("Email"); }
        }

        private double _Salary;
        public double Salary
        {
            get { return _Salary; }
            set { _Salary = value; RaisePropertyChanged("Salary"); }
        }

        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; RaisePropertyChanged("Phone"); }
        }

        private string _Position;
        public string Position
        {
            get { return _Position; }
            set { _Position = value; RaisePropertyChanged("Position"); }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; RaisePropertyChanged("Address"); }
        }

        private string _DateOfBirth;
        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; RaisePropertyChanged("DateOfBirth"); }
        }

        private string _DateOfHire;
        public string DateOfHire
        {
            get { return _DateOfHire; }
            set { _DateOfHire = value; RaisePropertyChanged("DateOfHire"); }
        }

        //[ForeignKey("UserId")]
        //public User User { get; set; }
        //public virtual User User { get; set; }
    }
}
