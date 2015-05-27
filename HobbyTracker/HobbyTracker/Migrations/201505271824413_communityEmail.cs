namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class communityEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Communities", "CommunityOwner", c => c.String());
            AddColumn("dbo.Communities", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Communities", "Email");
            DropColumn("dbo.Communities", "CommunityOwner");
        }
    }
}
