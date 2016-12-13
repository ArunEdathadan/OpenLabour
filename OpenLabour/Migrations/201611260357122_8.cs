namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.EventMasters", "CityID", "dbo.Cities");
            DropForeignKey("dbo.EventMasters", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces");
            DropForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices");
            DropForeignKey("dbo.EventMasters", "StateID", "dbo.States");
            DropIndex("dbo.EventMasters", new[] { "CityID" });
            DropIndex("dbo.EventMasters", new[] { "StateID" });
            DropIndex("dbo.EventMasters", new[] { "CountryID" });
            DropIndex("dbo.EventMasters", new[] { "AreaID" });
            DropIndex("dbo.EventMasters", new[] { "PostOfficeID" });
            DropIndex("dbo.EventMasters", new[] { "LocalPlaceID" });
            AlterColumn("dbo.EventMasters", "CityID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventMasters", "StateID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventMasters", "CountryID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventMasters", "AreaID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventMasters", "PostOfficeID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventMasters", "LocalPlaceID", c => c.Int(nullable: false));
            CreateIndex("dbo.EventMasters", "CountryID");
            CreateIndex("dbo.EventMasters", "CityID");
            CreateIndex("dbo.EventMasters", "StateID");
            CreateIndex("dbo.EventMasters", "AreaID");
            CreateIndex("dbo.EventMasters", "PostOfficeID");
            CreateIndex("dbo.EventMasters", "LocalPlaceID");
            AddForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas", "AreaID", cascadeDelete:false);
            AddForeignKey("dbo.EventMasters", "CityID", "dbo.Cities", "CityID", cascadeDelete: false);
            AddForeignKey("dbo.EventMasters", "CountryID", "dbo.Countries", "CountryID", cascadeDelete: false);
            AddForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces", "LocalPlaceID", cascadeDelete: false);
            AddForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices", "PostOfficeID", cascadeDelete: false);
            AddForeignKey("dbo.EventMasters", "StateID", "dbo.States", "StateID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventMasters", "StateID", "dbo.States");
            DropForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices");
            DropForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces");
            DropForeignKey("dbo.EventMasters", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.EventMasters", "CityID", "dbo.Cities");
            DropForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas");
            DropIndex("dbo.EventMasters", new[] { "LocalPlaceID" });
            DropIndex("dbo.EventMasters", new[] { "PostOfficeID" });
            DropIndex("dbo.EventMasters", new[] { "AreaID" });
            DropIndex("dbo.EventMasters", new[] { "StateID" });
            DropIndex("dbo.EventMasters", new[] { "CityID" });
            DropIndex("dbo.EventMasters", new[] { "CountryID" });
            AlterColumn("dbo.EventMasters", "LocalPlaceID", c => c.Int());
            AlterColumn("dbo.EventMasters", "PostOfficeID", c => c.Int());
            AlterColumn("dbo.EventMasters", "AreaID", c => c.Int());
            AlterColumn("dbo.EventMasters", "CountryID", c => c.Int());
            AlterColumn("dbo.EventMasters", "StateID", c => c.Int());
            AlterColumn("dbo.EventMasters", "CityID", c => c.Int());
            CreateIndex("dbo.EventMasters", "LocalPlaceID");
            CreateIndex("dbo.EventMasters", "PostOfficeID");
            CreateIndex("dbo.EventMasters", "AreaID");
            CreateIndex("dbo.EventMasters", "CountryID");
            CreateIndex("dbo.EventMasters", "StateID");
            CreateIndex("dbo.EventMasters", "CityID");
            AddForeignKey("dbo.EventMasters", "StateID", "dbo.States", "StateID");
            AddForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices", "PostOfficeID");
            AddForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces", "LocalPlaceID");
            AddForeignKey("dbo.EventMasters", "CountryID", "dbo.Countries", "CountryID");
            AddForeignKey("dbo.EventMasters", "CityID", "dbo.Cities", "CityID");
            AddForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas", "AreaID");
        }
    }
}
