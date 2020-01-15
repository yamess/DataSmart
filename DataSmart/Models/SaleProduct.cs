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
    [Table("Product", Schema = "Sale")]
    public class SaleProduct : BaseModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string AttributeType { get; set; }
        public string AttributeValue { get; set; }

        public virtual Stock Stock { get; set; }
    }
}
