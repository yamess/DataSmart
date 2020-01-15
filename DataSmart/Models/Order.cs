using DataSmart.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSmart.Models
{
    public class Order : BaseModel
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal GrandTotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalNetAmount { get; set; }
        public int NumberOfItem { get; set; }
        public bool IsFullyPaid { get; set; }
        public decimal DueAmount { get; set; }
        public string Descripton { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer{ get; set; }

        public virtual ICollection<SaleProduct> Products { get; set; }
    }
}
