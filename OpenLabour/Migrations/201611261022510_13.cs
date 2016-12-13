namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserContactVerifications",
                c => new
                    {
                        UserContactVerifyID = c.Int(nullable: false, identity: true),
                        UserContactID = c.Int(nullable: false),
                        Description = c.String(),
                        VerficationDate = c.DateTime(nullable: false),
                        VerifiedByUserID = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserContactVerifyID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.UserContacts", t => t.UserContactID, cascadeDelete: true)
                .Index(t => t.UserContactID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserContactVerificationDocuments",
                c => new
                    {
                        UserContactVerificationSupportDocID = c.Int(nullable: false, identity: true),
                        UserContactVerificationID = c.Int(nullable: false),
                        FileUrl = c.String(),
                        Description = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserContactVerificationSupportDocID)
                .ForeignKey("dbo.UserContactVerifications", t => t.UserContactVerificationID, cascadeDelete: true)
                .Index(t => t.UserContactVerificationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserContactVerificationDocuments", "UserContactVerificationID", "dbo.UserContactVerifications");
            DropForeignKey("dbo.UserContactVerifications", "UserContactID", "dbo.UserContacts");
            DropForeignKey("dbo.UserContactVerifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserContactVerificationDocuments", new[] { "UserContactVerificationID" });
            DropIndex("dbo.UserContactVerifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserContactVerifications", new[] { "UserContactID" });
            DropTable("dbo.UserContactVerificationDocuments");
            DropTable("dbo.UserContactVerifications");
        }
    }
}
