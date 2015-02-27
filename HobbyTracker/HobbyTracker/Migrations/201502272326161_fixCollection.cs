namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCollection : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Collections", "UserID");
            DropColumn("dbo.Collections", "ItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Collections", "ItemID", c => c.Int(nullable: false));
            AddColumn("dbo.Collections", "UserID", c => c.Int(nullable: false));
        }
    }
}
