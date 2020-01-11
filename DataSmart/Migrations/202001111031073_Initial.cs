namespace DataSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateOfRecord", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DateOfRecord", c => c.DateTime(nullable: false));
        }
    }
}
