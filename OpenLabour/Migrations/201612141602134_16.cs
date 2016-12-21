namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganisationVerifications",
                c => new
                    {
                        OrganisationVerificationID = c.Int(nullable: false, identity: true),
                        OrganisationID = c.Int(nullable: false),
                        Description = c.String(),
                        VerficationDate = c.DateTime(nullable: false),
                        VerifiedByUserID = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrganisationVerificationID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Organisations", t => t.OrganisationID, cascadeDelete: false)
                .Index(t => t.OrganisationID)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrganisationVerifications", "OrganisationID", "dbo.Organisations");
            DropForeignKey("dbo.OrganisationVerifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.OrganisationVerifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.OrganisationVerifications", new[] { "OrganisationID" });
            DropTable("dbo.OrganisationVerifications");
        }
    }
}
