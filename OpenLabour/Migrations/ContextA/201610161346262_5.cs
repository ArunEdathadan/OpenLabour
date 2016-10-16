namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventMasters",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        Title = c.String(),
                        SmallDescription = c.String(),
                        MetaTags = c.String(),
                        MetaDescription = c.String(),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            AddColumn("dbo.AspNetUsers", "ParentUserID", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventMasters", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.EventMasters", new[] { "UserID" });
            DropColumn("dbo.AspNetUsers", "ParentUserID");
            DropTable("dbo.EventMasters");
        }
    }
}
