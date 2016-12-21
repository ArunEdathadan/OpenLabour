namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganisationVerificationDocuments",
                c => new
                    {
                        OrganisationVerificationSupportDocID = c.Int(nullable: false, identity: true),
                        OrganisationVerificationID = c.Int(nullable: false),
                        FileUrl = c.String(),
                        Description = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrganisationVerificationSupportDocID)
                .ForeignKey("dbo.OrganisationVerifications", t => t.OrganisationVerificationID, cascadeDelete: true)
                .Index(t => t.OrganisationVerificationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrganisationVerificationDocuments", "OrganisationVerificationID", "dbo.OrganisationVerifications");
            DropIndex("dbo.OrganisationVerificationDocuments", new[] { "OrganisationVerificationID" });
            DropTable("dbo.OrganisationVerificationDocuments");
        }
    }
}
