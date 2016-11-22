namespace OpenLabour.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "CustomerAddressID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddPrimaryKey("dbo.Customers", "CustomerAddressID");
            DropColumn("dbo.Customers", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "CustomerAddressID");
            AddPrimaryKey("dbo.Customers", "CustomerID");
        }
    }
}
