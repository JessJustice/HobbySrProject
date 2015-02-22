namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.Item", "ItemName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "ItemName");
            DropTable("dbo.User");
        }
    }
}
