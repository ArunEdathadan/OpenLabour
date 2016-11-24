namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetTypes", "IsActive", c => c.Boolean(nullable: false,defaultValue:false));
            AddColumn("dbo.UserAssetVerificationDocuments", "IsTrue", c => c.Boolean(nullable: false,defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAssetVerificationDocuments", "IsTrue");
            DropColumn("dbo.AssetTypes", "IsActive");
        }
    }
}
