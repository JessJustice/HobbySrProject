namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Privateattribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Collections", "Private", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Collections", "Private");
        }
    }
}
