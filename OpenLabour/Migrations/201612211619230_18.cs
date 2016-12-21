namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QualityRatings",
                c => new
                    {
                        QualityRatingID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        RatedOnUserID = c.String(),
                        RatedByUserID = c.String(),
                    })
                .PrimaryKey(t => t.QualityRatingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QualityRatings");
        }
    }
}
