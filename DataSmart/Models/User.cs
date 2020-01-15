using DataSmart.Helpers;
using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSmart.Models
{
    public class User : BaseModel
    {

        public User()
        {
            Employee = new Employee();
        }

        [Key]
        public int UserId { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string UserName
        {
            get
            {
                return (Employee.LastName.Left(3) + UserId.ToString()).ToUpper();
            }
            private set
            {
                //Just need this here to trick EF 
            }
        }

        public string Password { get; set; }

        

        
    }
}


