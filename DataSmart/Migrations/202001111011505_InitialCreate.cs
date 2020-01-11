namespace DataSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeSIN = c.String(maxLength: 4000),
                        FirstName = c.String(maxLength: 4000),
                        LastName = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 4000),
                        Salary = c.Double(nullable: false),
                        Phone = c.String(maxLength: 4000),
                        Position = c.String(maxLength: 4000),
                        Address = c.String(maxLength: 4000),
                        DateOfBirth = c.String(maxLength: 4000),
                        DateOfHire = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .Index(t => t.EmployeeSIN, unique: true);
            
            CreateTable(
                "dbo.ProductStructures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_1 = c.String(maxLength: 4000),
                        Category_2 = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 4000),
                        ProductCategory_1 = c.String(maxLength: 4000),
                        ProductCategory_2 = c.String(maxLength: 4000),
                        ProductCategory_3 = c.String(maxLength: 4000),
                        UnitPurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        DateOfPurchase = c.String(maxLength: 4000),
                        DateOfRecord = c.DateTime(nullable: false),
                        UnitSalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Supplier = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "EmployeeSIN" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductStructures");
            DropTable("dbo.Employees");
        }
    }
}
