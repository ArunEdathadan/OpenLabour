namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsAgent", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsEmployee", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsOwner", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsOwner");
            DropColumn("dbo.AspNetUsers", "IsEmployee");
            DropColumn("dbo.AspNetUsers", "IsAgent");
        }
    }
}
