namespace WarehouseDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brand", "Id", "dbo.Products");
            DropForeignKey("dbo.Category", "Id", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "Orders_Id", "dbo.Orders");
            DropForeignKey("dbo.Products", "OrderItems_Id", "dbo.OrderItems");
            DropForeignKey("dbo.Employee", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Brand", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "OrderItems_Id" });
            DropIndex("dbo.Category", new[] { "Id" });
            DropIndex("dbo.Orders", new[] { "Customers_Id" });
            DropIndex("dbo.OrderItems", new[] { "Orders_Id" });
            DropIndex("dbo.Employee", new[] { "Order_Id" });
            DropColumn("dbo.OrderItems", "Id");
            DropColumn("dbo.OrderItems", "Product_Id");
            RenameColumn(table: "dbo.OrderItems", name: "Orders_Id", newName: "Id");
            RenameColumn(table: "dbo.OrderItems", name: "OrderItems_Id", newName: "Product_Id");
            RenameColumn(table: "dbo.Orders", name: "Order_Id", newName: "Employee_Id");
            DropPrimaryKey("dbo.OrderItems");
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Quanity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        ContactName = c.String(),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        PostCode = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "UnitPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "UnitsOnOrder", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Brand_Id", c => c.Int());
            AddColumn("dbo.Category", "Description", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Orders", "RequiredDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderItems", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OrderItems", new[] { "Id", "Product_Id" });
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "SupplierId");
            CreateIndex("dbo.Products", "Brand_Id");
            CreateIndex("dbo.OrderItems", "Id");
            CreateIndex("dbo.OrderItems", "Product_Id");
            CreateIndex("dbo.Orders", "customers_Id");
            CreateIndex("dbo.Orders", "Employee_Id");
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "Brand_Id", "dbo.Brand", "Id");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Employee_Id", "dbo.Employee", "Id");
            DropColumn("dbo.Products", "InStock");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "OrderItems_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "OrderItems_Id", c => c.Int());
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "InStock", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "Id", "dbo.Orders");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brand");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Stocks", "Id", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.Orders", new[] { "customers_Id" });
            DropIndex("dbo.OrderItems", new[] { "Product_Id" });
            DropIndex("dbo.OrderItems", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropPrimaryKey("dbo.OrderItems");
            AlterColumn("dbo.OrderItems", "Id", c => c.Int());
            DropColumn("dbo.Orders", "RequiredDate");
            DropColumn("dbo.Category", "Description");
            DropColumn("dbo.Products", "Brand_Id");
            DropColumn("dbo.Products", "UnitsOnOrder");
            DropColumn("dbo.Products", "UnitPrice");
            DropColumn("dbo.Products", "SupplierId");
            DropColumn("dbo.Products", "CategoryId");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Stocks");
            AddPrimaryKey("dbo.OrderItems", "Id");
            RenameColumn(table: "dbo.Orders", name: "Employee_Id", newName: "Order_Id");
            RenameColumn(table: "dbo.OrderItems", name: "Product_Id", newName: "OrderItems_Id");
            RenameColumn(table: "dbo.OrderItems", name: "Id", newName: "Orders_Id");
            AddColumn("dbo.OrderItems", "Product_Id", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Employee", "Order_Id");
            CreateIndex("dbo.OrderItems", "Orders_Id");
            CreateIndex("dbo.Orders", "Customers_Id");
            CreateIndex("dbo.Category", "Id");
            CreateIndex("dbo.Products", "OrderItems_Id");
            CreateIndex("dbo.Brand", "Id");
            AddForeignKey("dbo.Employee", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "OrderItems_Id", "dbo.OrderItems", "Id");
            AddForeignKey("dbo.OrderItems", "Orders_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Category", "Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Brand", "Id", "dbo.Products", "Id");
        }
    }
}
