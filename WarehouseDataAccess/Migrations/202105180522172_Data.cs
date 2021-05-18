namespace WarehouseDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Data : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "PassWordSalt", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "PassWordSalt", c => c.String(nullable: false));
        }
    }
}
