namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommunityIDinComment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Community_CommunityID", "dbo.Communities");
            DropIndex("dbo.Comments", new[] { "Community_CommunityID" });
            RenameColumn(table: "dbo.Comments", name: "Community_CommunityID", newName: "CommunityID");
            AlterColumn("dbo.Comments", "CommunityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "CommunityID");
            AddForeignKey("dbo.Comments", "CommunityID", "dbo.Communities", "CommunityID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "CommunityID", "dbo.Communities");
            DropIndex("dbo.Comments", new[] { "CommunityID" });
            AlterColumn("dbo.Comments", "CommunityID", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "CommunityID", newName: "Community_CommunityID");
            CreateIndex("dbo.Comments", "Community_CommunityID");
            AddForeignKey("dbo.Comments", "Community_CommunityID", "dbo.Communities", "CommunityID");
        }
    }
}
