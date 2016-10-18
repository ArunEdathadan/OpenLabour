namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentReplyMasters",
                c => new
                    {
                        CommentReplyID = c.Int(nullable: false, identity: true),
                        CommentDetail = c.String(),
                        CommentedBy = c.String(nullable: false, maxLength: 128),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentReplyID)
                .ForeignKey("dbo.AspNetUsers", t => t.CommentedBy, cascadeDelete: false)
                .ForeignKey("dbo.CommentReplyMasters", t => t.ParentID)
                .Index(t => t.CommentedBy)
                .Index(t => t.ParentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentReplyMasters", "ParentID", "dbo.CommentReplyMasters");
            DropForeignKey("dbo.CommentReplyMasters", "CommentedBy", "dbo.AspNetUsers");
            DropIndex("dbo.CommentReplyMasters", new[] { "ParentID" });
            DropIndex("dbo.CommentReplyMasters", new[] { "CommentedBy" });
            DropTable("dbo.CommentReplyMasters");
        }
    }
}
