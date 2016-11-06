namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganisationAssets",
                c => new
                    {
                        UserAssetID = c.Int(nullable: false, identity: true),
                        AssetTitle = c.String(),
                        AssetDetails = c.String(),
                        PhoneNumber = c.String(),
                        VehicleNumber = c.String(),
                        InstitutionNumber = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        AssetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAssetID)
                .ForeignKey("dbo.AssetTypes", t => t.AssetID, cascadeDelete: true)
                .Index(t => t.AssetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrganisationAssets", "AssetID", "dbo.AssetTypes");
            DropIndex("dbo.OrganisationAssets", new[] { "AssetID" });
            DropTable("dbo.OrganisationAssets");
        }
    }
}
