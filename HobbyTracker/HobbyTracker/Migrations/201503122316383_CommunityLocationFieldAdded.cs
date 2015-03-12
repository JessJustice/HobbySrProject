namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommunityLocationFieldAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Communities", "CommunityLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Communities", "CommunityLocation");
        }
    }
}
