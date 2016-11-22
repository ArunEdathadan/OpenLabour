namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedByUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUserID)
                .Index(t => t.CreatedByUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "CreatedByUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "CreatedByUserID" });
            DropTable("dbo.Categories");
        }
    }
}
