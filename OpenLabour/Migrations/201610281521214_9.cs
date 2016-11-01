namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.JobEngements", newName: "JobEngagements");
            CreateTable(
                "dbo.SubsriptionToUsers",
                c => new
                    {
                        UserSubsriptionID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SubscribedByUserID = c.String(),
                        SubscribedOnUserID = c.String(nullable: false, maxLength: 128),
                        Active = c.Boolean(),
                        SubscribedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserSubsriptionID)
                .ForeignKey("dbo.AspNetUsers", t => t.SubscribedOnUserID, cascadeDelete: true)
                .Index(t => t.SubscribedOnUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubsriptionToUsers", "SubscribedOnUserID", "dbo.AspNetUsers");
            DropIndex("dbo.SubsriptionToUsers", new[] { "SubscribedOnUserID" });
            DropTable("dbo.SubsriptionToUsers");
            RenameTable(name: "dbo.JobEngagements", newName: "JobEngements");
        }
    }
}
