namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        JobTypeID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobID = c.Int(),
                    })
                .PrimaryKey(t => t.JobTypeID)
                .ForeignKey("dbo.JobTypes", t => t.JobID)
                .Index(t => t.JobID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobTypes", "JobID", "dbo.JobTypes");
            DropIndex("dbo.JobTypes", new[] { "JobID" });
            DropTable("dbo.JobTypes");
        }
    }
}
