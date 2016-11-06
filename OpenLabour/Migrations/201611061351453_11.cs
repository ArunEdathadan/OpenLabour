namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.States", "CountryID", c => c.Int(nullable: false));
            CreateIndex("dbo.States", "CountryID");
            AddForeignKey("dbo.States", "CountryID", "dbo.Countries", "CountryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.States", "CountryID", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryID" });
            DropColumn("dbo.States", "CountryID");
        }
    }
}
