namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAssets", "AssetTitle", c => c.String());
            AddColumn("dbo.UserAssets", "AssetDetails", c => c.String());
            AddColumn("dbo.UserAssets", "PhoneNumber", c => c.String());
            AddColumn("dbo.UserAssets", "VehicleNumber", c => c.String());
            AddColumn("dbo.UserAssets", "InstitutionNumber", c => c.String());
            AddColumn("dbo.UserAssets", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.UserAssets", "Asset");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAssets", "Asset", c => c.String());
            DropColumn("dbo.UserAssets", "CreatedOn");
            DropColumn("dbo.UserAssets", "InstitutionNumber");
            DropColumn("dbo.UserAssets", "VehicleNumber");
            DropColumn("dbo.UserAssets", "PhoneNumber");
            DropColumn("dbo.UserAssets", "AssetDetails");
            DropColumn("dbo.UserAssets", "AssetTitle");
        }
    }
}
