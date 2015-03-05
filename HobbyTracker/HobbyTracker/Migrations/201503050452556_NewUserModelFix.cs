namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUserModelFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewUserModels",
                c => new
                    {
                        NewUserModelID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.NewUserModelID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewUserModels");
        }
    }
}
