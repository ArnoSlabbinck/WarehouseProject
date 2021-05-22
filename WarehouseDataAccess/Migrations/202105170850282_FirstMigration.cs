namespace WarehouseDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        MadeIn = c.String(nullable: false),
                        InStock = c.Boolean(nullable: false),
                        ModelYear = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        OrderItems_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderItems", t => t.OrderItems_Id)
                .Index(t => t.OrderItems_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 50),
                        Number = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        RegularCustomer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderStatus = c.String(nullable: false, maxLength: 50),
                        OrderDate = c.DateTime(nullable: false),
                        ShipDate = c.DateTime(nullable: false),
                        customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_Id)
                .Index(t => t.customer_Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Role = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PassWord = c.String(nullable: false),
                        PassWordSalt = c.String(nullable: false),
                        FailedPasswordAttemptCount = c.Int(nullable: false),
                        IsLockedOut = c.Boolean(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        Supervisor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Supervisor", t => t.Supervisor_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Supervisor_Id);
            
            CreateTable(
                "dbo.Supervisor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPriceWithoutTax = c.Double(nullable: false),
                        PriceWithTax = c.Double(nullable: false),
                        Orders_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Orders_Id)
                .Index(t => t.Orders_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "OrderItems_Id", "dbo.OrderItems");
            DropForeignKey("dbo.OrderItems", "Orders_Id", "dbo.Orders");
            DropForeignKey("dbo.Employee", "Supervisor_Id", "dbo.Supervisor");
            DropForeignKey("dbo.Employee", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Brand", "Id", "dbo.Products");
            DropForeignKey("dbo.Category", "Id", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "Orders_Id" });
            DropIndex("dbo.Employee", new[] { "Supervisor_Id" });
            DropIndex("dbo.Employee", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "customer_Id" });
            DropIndex("dbo.Category", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "OrderItems_Id" });
            DropIndex("dbo.Brand", new[] { "Id" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.Supervisor");
            DropTable("dbo.Employee");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Category");
            DropTable("dbo.Products");
            DropTable("dbo.Brand");
        }
    }
}
