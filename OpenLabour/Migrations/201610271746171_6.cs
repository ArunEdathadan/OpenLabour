namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobEngements",
                c => new
                    {
                        JobEngID = c.Int(nullable: false, identity: true),
                        JobDescription = c.String(),
                        ConfirationCount = c.Int(nullable: false),
                        JobTitle = c.String(),
                        JobDetails = c.String(),
                        OrgID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.JobEngID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.OrgInstitutionCompanies", t => t.OrgID, cascadeDelete: true)
                .Index(t => t.OrgID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobEngements", "OrgID", "dbo.OrgInstitutionCompanies");
            DropForeignKey("dbo.JobEngements", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.JobEngements", new[] { "UserID" });
            DropIndex("dbo.JobEngements", new[] { "OrgID" });
            DropTable("dbo.JobEngements");
        }
    }
}
