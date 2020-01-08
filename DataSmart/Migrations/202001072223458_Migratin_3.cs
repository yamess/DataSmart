namespace DataSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratin_3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
    }
}
