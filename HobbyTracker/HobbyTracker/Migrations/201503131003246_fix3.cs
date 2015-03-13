namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectionItems", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Communities", "CommunityLoc", c => c.String());
            CreateIndex("dbo.CollectionItems", "User_Id");
            AddForeignKey("dbo.CollectionItems", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionItems", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CollectionItems", new[] { "User_Id" });
            DropColumn("dbo.Communities", "CommunityLoc");
            DropColumn("dbo.CollectionItems", "User_Id");
        }
    }
}
