namespace WarehouseDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        MadeIn = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        ModelYear = c.DateTime(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        UnitsOnOrder = c.Int(nullable: false),
                        Brand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.Brand_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId)
                .Index(t => t.Brand_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
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
                        Products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Orders_Id)
                .ForeignKey("dbo.Products", t => t.Products_Id)
                .Index(t => t.Orders_Id)
                .Index(t => t.Products_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderStatus = c.String(nullable: false, maxLength: 50),
                        OrderDate = c.DateTime(nullable: false),
                        RequiredDate = c.DateTime(nullable: false),
                        ShipDate = c.DateTime(nullable: false),
                        customers_Id = c.Int(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customers_Id)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .Index(t => t.customers_Id)
                .Index(t => t.Employee_Id);
            
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
                .ForeignKey("dbo.Supervisor", t => t.Supervisor_Id)
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
                "dbo.Test",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Supervisor_Id", "dbo.Supervisor");
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brand");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Stocks", "Id", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "Products_Id", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "Orders_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "customers_Id", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Category");
            DropIndex("dbo.Employee", new[] { "Supervisor_Id" });
            DropIndex("dbo.Stocks", new[] { "Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.Orders", new[] { "customers_Id" });
            DropIndex("dbo.OrderItems", new[] { "Products_Id" });
            DropIndex("dbo.OrderItems", new[] { "Orders_Id" });
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Test");
            DropTable("dbo.Supervisor");
            DropTable("dbo.Employee");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Stocks");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Category");
            DropTable("dbo.Products");
            DropTable("dbo.Brand");
        }
    }
}
