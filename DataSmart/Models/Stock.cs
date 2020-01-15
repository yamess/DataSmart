using DataSmart.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSmart.Models
{
    public class Stock : BaseModel
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime? DateOfRecord { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual SaleProduct SaleProducts { get; set; }
        public virtual Supplier Suppliers { get; set; }
        public virtual User User { get; set; }
    }
}
