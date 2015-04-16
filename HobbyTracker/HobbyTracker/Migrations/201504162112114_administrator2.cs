namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class administrator2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Administrators");
        }
    }
}
