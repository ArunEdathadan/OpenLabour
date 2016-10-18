namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventMasters", "ParentID", c => c.Int());
            CreateIndex("dbo.EventMasters", "ParentID");
            AddForeignKey("dbo.EventMasters", "ParentID", "dbo.EventMasters", "EventID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventMasters", "ParentID", "dbo.EventMasters");
            DropIndex("dbo.EventMasters", new[] { "ParentID" });
            DropColumn("dbo.EventMasters", "ParentID");
        }
    }
}
