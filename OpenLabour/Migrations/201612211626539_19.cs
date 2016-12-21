namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QualityRatings", "RatedByUserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.QualityRatings", "RatedByUserID");
            AddForeignKey("dbo.QualityRatings", "RatedByUserID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QualityRatings", "RatedByUserID", "dbo.AspNetUsers");
            DropIndex("dbo.QualityRatings", new[] { "RatedByUserID" });
            AlterColumn("dbo.QualityRatings", "RatedByUserID", c => c.String());
        }
    }
}
