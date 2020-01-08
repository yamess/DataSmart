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
                        Salaire = c.Double(nullable: false),
                        Phone = c.String(maxLength: 4000),
                        Position = c.String(maxLength: 4000),
                        Address = c.String(maxLength: 4000),
                        DateOfBirth = c.String(maxLength: 4000),
                        DateOfHire = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ProductName = c.String(maxLength: 4000),
                        ProductCategory_1 = c.String(maxLength: 4000),
                        ProductCategory_2 = c.String(maxLength: 4000),
                        ProductCategory_3 = c.String(maxLength: 4000),
                        UnitPurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        DateOfPurchase = c.DateTime(nullable: false),
                        DateOfRecord = c.DateTime(nullable: false),
                        UnitSalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Employees");
        }
    }
}
