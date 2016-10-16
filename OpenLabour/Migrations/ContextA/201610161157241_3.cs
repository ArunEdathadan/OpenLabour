namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserImageStores",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageLoc = c.String(),
                        Description = c.String(),
                        ProfilePic = c.String(),
                        Active = c.Boolean(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserImageStores", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.UserImageStores", new[] { "UserID" });
            DropTable("dbo.UserImageStores");
        }
    }
}
