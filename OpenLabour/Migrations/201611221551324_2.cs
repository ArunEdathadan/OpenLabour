namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobEngagements", "JobTypeID", c => c.Int());
            CreateIndex("dbo.JobEngagements", "JobTypeID");
            AddForeignKey("dbo.JobEngagements", "JobTypeID", "dbo.JobTypes", "JobTypeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobEngagements", "JobTypeID", "dbo.JobTypes");
            DropIndex("dbo.JobEngagements", new[] { "JobTypeID" });
            DropColumn("dbo.JobEngagements", "JobTypeID");
        }
    }
}
