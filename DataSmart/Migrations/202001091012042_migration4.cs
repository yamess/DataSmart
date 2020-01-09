namespace DataSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Double(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeSIN", c => c.String(nullable: false, maxLength: 4000));
            CreateIndex("dbo.Employees", "EmployeeSIN", unique: true);
            DropColumn("dbo.Employees", "Salaire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Salaire", c => c.Double(nullable: false));
            DropIndex("dbo.Employees", new[] { "EmployeeSIN" });
            AlterColumn("dbo.Employees", "EmployeeSIN", c => c.String(maxLength: 4000));
            DropColumn("dbo.Employees", "Salary");
        }
    }
}
