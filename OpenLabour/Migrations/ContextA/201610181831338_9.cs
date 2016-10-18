namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentMasters", "CommentedBy", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CommentMasters", "CommentedBy");
            AddForeignKey("dbo.CommentMasters", "CommentedBy", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentMasters", "CommentedBy", "dbo.AspNetUsers");
            DropIndex("dbo.CommentMasters", new[] { "CommentedBy" });
            DropColumn("dbo.CommentMasters", "CommentedBy");
        }
    }
}