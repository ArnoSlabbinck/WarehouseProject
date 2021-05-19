namespace WarehouseDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTest : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "customers_Id" });
            CreateIndex("dbo.Orders", "Customers_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "Customers_Id" });
            CreateIndex("dbo.Orders", "customers_Id");
        }
    }
}
