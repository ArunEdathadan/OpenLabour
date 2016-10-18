namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentMasters",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentDetails = c.String(),
                        UpVoteCount = c.Int(nullable: false),
                        DownVoteCount = c.Int(nullable: false),
                        CommentEmotion = c.Int(nullable: false),
                        EventID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.EventMasters", t => t.EventID)
                .Index(t => t.EventID);
            
            AddColumn("dbo.EventMasters", "TitleNative", c => c.String());
            AddColumn("dbo.EventMasters", "SmallDescriptionNative", c => c.String());
            AddColumn("dbo.EventMasters", "BigDescriptionNative", c => c.String());
            AddColumn("dbo.EventMasters", "BigDescription", c => c.String());
            AddColumn("dbo.EventMasters", "HtmlContent", c => c.String());
            AddColumn("dbo.EventMasters", "MetaNative", c => c.String());
            AddColumn("dbo.EventMasters", "CommentMaster_CommentID", c => c.Int());
            CreateIndex("dbo.EventMasters", "CommentMaster_CommentID");
            AddForeignKey("dbo.EventMasters", "CommentMaster_CommentID", "dbo.CommentMasters", "CommentID");
            DropColumn("dbo.EventMasters", "Details");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventMasters", "Details", c => c.String());
            DropForeignKey("dbo.EventMasters", "CommentMaster_CommentID", "dbo.CommentMasters");
            DropForeignKey("dbo.CommentMasters", "EventID", "dbo.EventMasters");
            DropIndex("dbo.CommentMasters", new[] { "EventID" });
            DropIndex("dbo.EventMasters", new[] { "CommentMaster_CommentID" });
            DropColumn("dbo.EventMasters", "CommentMaster_CommentID");
            DropColumn("dbo.EventMasters", "MetaNative");
            DropColumn("dbo.EventMasters", "HtmlContent");
            DropColumn("dbo.EventMasters", "BigDescription");
            DropColumn("dbo.EventMasters", "BigDescriptionNative");
            DropColumn("dbo.EventMasters", "SmallDescriptionNative");
            DropColumn("dbo.EventMasters", "TitleNative");
            DropTable("dbo.CommentMasters");
        }
    }
}
