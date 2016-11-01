namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        UserImageID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        ImageDesc = c.String(),
                        IsActive = c.Boolean(),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserImageID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserImages", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.UserImages", new[] { "UserID" });
            DropTable("dbo.UserImages");
        }
    }
}
