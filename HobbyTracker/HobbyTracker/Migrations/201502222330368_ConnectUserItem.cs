namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectUserItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "UserID");
            AddForeignKey("dbo.Item", "UserID", "dbo.User", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "UserID", "dbo.User");
            DropIndex("dbo.Item", new[] { "UserID" });
            DropColumn("dbo.Item", "UserID");
        }
    }
}
