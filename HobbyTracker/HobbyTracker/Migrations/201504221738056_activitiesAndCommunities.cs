namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activitiesAndCommunities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "Community_CommunityID", "dbo.Communities");
            DropIndex("dbo.Activities", new[] { "Community_CommunityID" });
            RenameColumn(table: "dbo.Activities", name: "Community_CommunityID", newName: "CommunityID");
            AlterColumn("dbo.Activities", "CommunityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "CommunityID");
            AddForeignKey("dbo.Activities", "CommunityID", "dbo.Communities", "CommunityID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "CommunityID", "dbo.Communities");
            DropIndex("dbo.Activities", new[] { "CommunityID" });
            AlterColumn("dbo.Activities", "CommunityID", c => c.Int());
            RenameColumn(table: "dbo.Activities", name: "CommunityID", newName: "Community_CommunityID");
            CreateIndex("dbo.Activities", "Community_CommunityID");
            AddForeignKey("dbo.Activities", "Community_CommunityID", "dbo.Communities", "CommunityID");
        }
    }
}
