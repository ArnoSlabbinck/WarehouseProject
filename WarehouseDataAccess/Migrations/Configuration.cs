namespace WarehouseDataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WarehouseModels;

    internal sealed class Configuration : DbMigrationsConfiguration<WarehouseDataAccess.WarehouseDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WarehouseDataAccess.WarehouseDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
            context.Customers.AddOrUpdate(
                h => h.FirstName,
                new Customers
                {
                    FirstName = "Dries",
                    LastName = "Mertens",
                    Country = "Belgium",
                    Street = "Koningslaan",
                    Number = "5",
                    Email = "Dries.Mertens@hotmail.com",
                    Phone = "0497060081",
                    City = "Aalst",
                    RegularCustomer = 10,

                },
                new Customers
                {
                    FirstName = "Romelu",
                    LastName = "Lukaku",
                    Country = "Belgium",
                    Street = "Keizerlei",
                    Number = "5",
                    Email = "Romelu.Lukaku@hotmail.com",
                    Phone = "0497060081",
                    City = "Anderlecht",
                    RegularCustomer = 10,

                },
                new Customers
                {
                    FirstName = "Eden",
                    LastName = "Hazard",
                    Country = "Belgium",
                    Street = "AndersLaan",
                    Number = "5",
                    Email = "Eden.Hazard@hotmail.com",
                    Phone = "0497060081",
                    City = "Duffel",
                    RegularCustomer = 5,

                }
                
                );
        }
    }
}
