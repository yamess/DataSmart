using DataSmart.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSmart.Models
{
    public class Customer : BaseModel
    {
        [Key]
        public int CustomerId { get; set; }

        public int UserId { get; set; }
        public string TypeOfCustomer { get; set; }
        public string EnterpriseName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("OrderId")]
        public virtual ICollection<Order> Order { get; set; }

    }
}
