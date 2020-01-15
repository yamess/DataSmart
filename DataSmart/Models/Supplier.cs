using DataSmart.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSmart.Models
{
    public class Supplier : BaseModel
    {
        public int SupplierId { get; set; }
        public string SupplierType { get; set; }
        public string Enterprise { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Email { get; set; }
    }
}
