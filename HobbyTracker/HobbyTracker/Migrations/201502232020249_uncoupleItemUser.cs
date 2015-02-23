namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uncoupleItemUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "UserID", "dbo.User");
            DropIndex("dbo.Item", new[] { "UserID" });
            DropColumn("dbo.Item", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "UserID");
            AddForeignKey("dbo.Item", "UserID", "dbo.User", "UserID", cascadeDelete: true);
        }
    }
}
