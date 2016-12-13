namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserImageVerifications",
                c => new
                    {
                        UserImageVerificationID = c.Int(nullable: false, identity: true),
                        UserImagesID = c.Int(nullable: false),
                        Description = c.String(),
                        VerficationDate = c.DateTime(nullable: false),
                        VerifiedByUserID = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserImageVerificationID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.UserImages", t => t.UserImagesID, cascadeDelete: true)
                .Index(t => t.UserImagesID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserImageVerificationDocuments",
                c => new
                    {
                        UserImageVerificationSupportDocID = c.Int(nullable: false, identity: true),
                        UserImageVerificationID = c.Int(nullable: false),
                        FileUrl = c.String(),
                        Description = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserImageVerificationSupportDocID)
                .ForeignKey("dbo.UserImageVerifications", t => t.UserImageVerificationID, cascadeDelete: true)
                .Index(t => t.UserImageVerificationID);
            
            CreateTable(
                "dbo.UserContributionMoneys",
                c => new
                    {
                        UserContributionMoneyID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2,defaultValue:0),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserContributionMoneyID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserContributionMoneys", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserImageVerificationDocuments", "UserImageVerificationID", "dbo.UserImageVerifications");
            DropForeignKey("dbo.UserImageVerifications", "UserImagesID", "dbo.UserImages");
            DropForeignKey("dbo.UserImageVerifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserContributionMoneys", new[] { "UserID" });
            DropIndex("dbo.UserImageVerificationDocuments", new[] { "UserImageVerificationID" });
            DropIndex("dbo.UserImageVerifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserImageVerifications", new[] { "UserImagesID" });
            DropTable("dbo.UserContributionMoneys");
            DropTable("dbo.UserImageVerificationDocuments");
            DropTable("dbo.UserImageVerifications");
        }
    }
}
