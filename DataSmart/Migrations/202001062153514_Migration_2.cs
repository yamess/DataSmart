﻿namespace DataSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Supplier", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Supplier");
        }
    }
}
