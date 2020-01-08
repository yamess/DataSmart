using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSmart.Models;
using System.Data.Entity;

namespace DataSmart.Helpers
{
    public class DataSmartDBContext : DbContext
    {
        public DataSmartDBContext() : base("DataSmartDB_dev") { }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Produits { get; set; } // Produits is the name of the table of Product that will created in the database
        public DbSet<ProductStructure> ProductStructure { get; set; }

    }
}
