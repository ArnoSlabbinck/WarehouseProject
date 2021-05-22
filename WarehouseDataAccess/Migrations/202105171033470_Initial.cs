namespace WarehouseDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "customer_Id", newName: "Customers_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_customer_Id", newName: "IX_Customers_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_Customers_Id", newName: "IX_customer_Id");
            RenameColumn(table: "dbo.Orders", name: "Customers_Id", newName: "customer_Id");
        }
    }
}
