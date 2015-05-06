namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentUser");
        }
    }
}
