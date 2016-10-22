namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAssets",
                c => new
                    {
                        UserAssetID = c.Int(nullable: false, identity: true),
                        Asset = c.String(),
                        AssetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAssetID)
                .ForeignKey("dbo.AssetTypes", t => t.AssetID, cascadeDelete: true)
                .Index(t => t.AssetID);
            
            CreateTable(
                "dbo.AssetTypes",
                c => new
                    {
                        AssetID = c.Int(nullable: false, identity: true),
                        AssectType = c.String(),
                    })
                .PrimaryKey(t => t.AssetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAssets", "AssetID", "dbo.AssetTypes");
            DropIndex("dbo.UserAssets", new[] { "AssetID" });
            DropTable("dbo.AssetTypes");
            DropTable("dbo.UserAssets");
        }
    }
}
