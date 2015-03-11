namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCommentCommunity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommunityComments", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.CommunityComments", "CommunityID", "dbo.Communities");
            DropIndex("dbo.CommunityComments", new[] { "CommunityID" });
            DropIndex("dbo.CommunityComments", new[] { "CommentID" });
            DropTable("dbo.CommunityComments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CommunityComments",
                c => new
                    {
                        CommunityID = c.Int(nullable: false),
                        CommentID = c.Int(nullable: false),
                        CommunityCommentID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CommunityCommentID);
            
            CreateIndex("dbo.CommunityComments", "CommentID");
            CreateIndex("dbo.CommunityComments", "CommunityID");
            AddForeignKey("dbo.CommunityComments", "CommunityID", "dbo.Communities", "CommunityID", cascadeDelete: true);
            AddForeignKey("dbo.CommunityComments", "CommentID", "dbo.Comments", "CommentID", cascadeDelete: true);
        }
    }
}
