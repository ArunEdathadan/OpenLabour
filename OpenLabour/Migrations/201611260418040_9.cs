namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.EventMasters", "CityID", "dbo.Cities");
            DropForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces");
            DropForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices");
            DropIndex("dbo.EventMasters", new[] { "CityID" });
            DropIndex("dbo.EventMasters", new[] { "AreaID" });
            DropIndex("dbo.EventMasters", new[] { "PostOfficeID" });
            DropIndex("dbo.EventMasters", new[] { "LocalPlaceID" });
            AlterColumn("dbo.EventMasters", "CityID", c => c.Int());
            AlterColumn("dbo.EventMasters", "AreaID", c => c.Int());
            AlterColumn("dbo.EventMasters", "PostOfficeID", c => c.Int());
            AlterColumn("dbo.EventMasters", "LocalPlaceID", c => c.Int());
            CreateIndex("dbo.EventMasters", "CityID");
            CreateIndex("dbo.EventMasters", "AreaID");
            CreateIndex("dbo.EventMasters", "PostOfficeID");
            CreateIndex("dbo.EventMasters", "LocalPlaceID");
            AddForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas", "AreaID");
            AddForeignKey("dbo.EventMasters", "CityID", "dbo.Cities", "CityID");
            AddForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces", "LocalPlaceID");
            AddForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices", "PostOfficeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices");
            DropForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces");
            DropForeignKey("dbo.EventMasters", "CityID", "dbo.Cities");
            DropForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas");
            DropIndex("dbo.EventMasters", new[] { "LocalPlaceID" });
            DropIndex("dbo.EventMasters", new[] { "PostOfficeID" });
            DropIndex("dbo.EventMasters", new[] { "AreaID" });
            DropIndex("dbo.EventMasters", new[] { "CityID" });
            AlterColumn("dbo.EventMasters", "LocalPlaceID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventMasters", "PostOfficeID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventMasters", "AreaID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventMasters", "CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.EventMasters", "LocalPlaceID");
            CreateIndex("dbo.EventMasters", "PostOfficeID");
            CreateIndex("dbo.EventMasters", "AreaID");
            CreateIndex("dbo.EventMasters", "CityID");
            AddForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices", "PostOfficeID", cascadeDelete: false);
            AddForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces", "LocalPlaceID", cascadeDelete: false);
            AddForeignKey("dbo.EventMasters", "CityID", "dbo.Cities", "CityID", cascadeDelete: false);
            AddForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas", "AreaID", cascadeDelete: false);
        }
    }
}
