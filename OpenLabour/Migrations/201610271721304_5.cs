namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrgInstitutionCompanies",
                c => new
                    {
                        OrgInstCompID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Brief = c.String(),
                        Description = c.String(),
                        IdentificationNumber = c.String(),
                        IdentificationType = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        GoogleMaps = c.String(),
                        IsVerfied = c.Boolean(),
                        OwnerID = c.String(),
                        IsBranch = c.Boolean(),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.OrgInstCompID)
                .ForeignKey("dbo.OrgInstitutionCompanies", t => t.ParentID)
                .Index(t => t.ParentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrgInstitutionCompanies", "ParentID", "dbo.OrgInstitutionCompanies");
            DropIndex("dbo.OrgInstitutionCompanies", new[] { "ParentID" });
            DropTable("dbo.OrgInstitutionCompanies");
        }
    }
}
