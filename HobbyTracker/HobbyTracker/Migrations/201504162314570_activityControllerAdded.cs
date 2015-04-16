namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activityControllerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        ActName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        WillAttend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Activities");
        }
    }
}
