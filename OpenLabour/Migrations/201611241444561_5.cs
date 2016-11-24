namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserAssetVerfications", newName: "UserAssetVerifications");
            CreateTable(
                "dbo.OrganisationImages",
                c => new
                    {
                        OrgImageID = c.Int(nullable: false, identity: true),
                        ImageThumpNailUrl = c.String(),
                        ImageLargeUrl = c.String(),
                        ImageDesc = c.String(),
                        IsActive = c.Boolean(),
                        UploadedDate = c.DateTime(nullable: false),
                        OrganisationID = c.Int(nullable: false),
                        UploadedByUser = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrgImageID)
                .ForeignKey("dbo.AspNetUsers", t => t.UploadedByUser, cascadeDelete: true)
                .ForeignKey("dbo.Organisations", t => t.OrganisationID, cascadeDelete: true)
                .Index(t => t.OrganisationID)
                .Index(t => t.UploadedByUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrganisationImages", "OrganisationID", "dbo.Organisations");
            DropForeignKey("dbo.OrganisationImages", "UploadedByUser", "dbo.AspNetUsers");
            DropIndex("dbo.OrganisationImages", new[] { "UploadedByUser" });
            DropIndex("dbo.OrganisationImages", new[] { "OrganisationID" });
            DropTable("dbo.OrganisationImages");
            RenameTable(name: "dbo.UserAssetVerifications", newName: "UserAssetVerfications");
        }
    }
}
