namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommunityActivitiesField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Community_CommunityID", c => c.Int());
            CreateIndex("dbo.Activities", "Community_CommunityID");
            AddForeignKey("dbo.Activities", "Community_CommunityID", "dbo.Communities", "CommunityID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "Community_CommunityID", "dbo.Communities");
            DropIndex("dbo.Activities", new[] { "Community_CommunityID" });
            DropColumn("dbo.Activities", "Community_CommunityID");
        }
    }
}
