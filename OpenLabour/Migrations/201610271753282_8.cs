namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobTypes", name: "JobID", newName: "JobParentID");
            RenameIndex(table: "dbo.JobTypes", name: "IX_JobID", newName: "IX_JobParentID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JobTypes", name: "IX_JobParentID", newName: "IX_JobID");
            RenameColumn(table: "dbo.JobTypes", name: "JobParentID", newName: "JobID");
        }
    }
}
