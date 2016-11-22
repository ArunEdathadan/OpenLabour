namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserAssetVerfications", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.UserAssetVerfications", "VerifiedByUserID");
            RenameColumn(table: "dbo.UserAssetVerfications", name: "ApplicationUser_Id", newName: "VerifiedByUserID");
            AlterColumn("dbo.UserAssetVerfications", "VerifiedByUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserAssetVerfications", "VerifiedByUserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserAssetVerfications", new[] { "VerifiedByUserID" });
            AlterColumn("dbo.UserAssetVerfications", "VerifiedByUserID", c => c.String());
            RenameColumn(table: "dbo.UserAssetVerfications", name: "VerifiedByUserID", newName: "ApplicationUser_Id");
            AddColumn("dbo.UserAssetVerfications", "VerifiedByUserID", c => c.String());
            CreateIndex("dbo.UserAssetVerfications", "ApplicationUser_Id");
        }
    }
}
