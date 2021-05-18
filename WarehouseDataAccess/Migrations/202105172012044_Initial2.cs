namespace WarehouseDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Gender", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Employee", "Salary", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "JobTitle", c => c.String(nullable: false));
            AddColumn("dbo.Supervisor", "Username", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Supervisor", "Password", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Employee", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Role", c => c.String(nullable: false));
            DropColumn("dbo.Supervisor", "Password");
            DropColumn("dbo.Supervisor", "Username");
            DropColumn("dbo.Employee", "JobTitle");
            DropColumn("dbo.Employee", "Salary");
            DropColumn("dbo.Employee", "Gender");
        }
    }
}
