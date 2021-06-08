using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WarehouseModels;

namespace WarehouseDataAccess
{
    public class WarehouseDBContext : DbContext
    {
        public WarehouseDBContext() : base("WarehouseDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WarehouseDBContext, Migrations.Configuration>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<WarehouseDBContext>());

        }
        public DbSet<Customers> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Products> Products {get; set;}

        public DbSet<Test> Tests { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderItems> OrderItems { get; set; }

        public DbSet<Supervisor> Supervisor { get; set; }
        
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Suppliers> Suppliers { get; set; }

        public DbSet<Stocks> Stocks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

}
