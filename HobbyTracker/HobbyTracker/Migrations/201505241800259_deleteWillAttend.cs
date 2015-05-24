namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteWillAttend : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Activities", "WillAttend");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "WillAttend", c => c.Boolean(nullable: false));
        }
    }
}
