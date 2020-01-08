
namespace DataSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductStructur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductStructures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_1 = c.String(maxLength: 4000),
                        Category_2 = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductStructures");
        }
    }
}
