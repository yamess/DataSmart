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
        [Key]
        public int UserId { get; set; }
        public int EmployeeId { get; set; }

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
        // Password genration example from PasswordGenerator package
        //var pwd = new Password().IncludeLowercase().IncludeUppercase().IncludeSpecial().LengthRequired(128);
        //var result = pwd.Next();
        public virtual Employee Employee { get; set; }
    }
}


