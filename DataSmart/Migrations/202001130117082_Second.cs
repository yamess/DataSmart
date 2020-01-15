namespace DataSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 4000),
                        Password = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Users", new[] { "EmployeeId" });
            DropTable("dbo.Users");
        }
    }
}
