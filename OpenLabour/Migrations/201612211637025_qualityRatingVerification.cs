namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qualityRatingVerification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QualityRatingVerifications",
                c => new
                    {
                        QualityRatingVerificationID = c.Int(nullable: false, identity: true),
                        QualityRatingID = c.Int(nullable: false),
                        Description = c.String(),
                        VerficationDate = c.DateTime(nullable: false),
                        VerifiedByUserID = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.QualityRatingVerificationID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.QualityRatings", t => t.QualityRatingID, cascadeDelete: true)
                .Index(t => t.QualityRatingID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.QualityRatingVerificationDocuments",
                c => new
                    {
                        QualityRatingVerificationSupportDocID = c.Int(nullable: false, identity: true),
                        QualityRatingVerificationID = c.Int(nullable: false),
                        FileUrl = c.String(),
                        Description = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QualityRatingVerificationSupportDocID)
                .ForeignKey("dbo.QualityRatingVerifications", t => t.QualityRatingVerificationID, cascadeDelete: true)
                .Index(t => t.QualityRatingVerificationID);
            
            AddColumn("dbo.QualityRatings", "RatedValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QualityRatingVerificationDocuments", "QualityRatingVerificationID", "dbo.QualityRatingVerifications");
            DropForeignKey("dbo.QualityRatingVerifications", "QualityRatingID", "dbo.QualityRatings");
            DropForeignKey("dbo.QualityRatingVerifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.QualityRatingVerificationDocuments", new[] { "QualityRatingVerificationID" });
            DropIndex("dbo.QualityRatingVerifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.QualityRatingVerifications", new[] { "QualityRatingID" });
            DropColumn("dbo.QualityRatings", "RatedValue");
            DropTable("dbo.QualityRatingVerificationDocuments");
            DropTable("dbo.QualityRatingVerifications");
        }
    }
}
