namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentModelFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Communities",
                c => new
                    {
                        CommunityID = c.Int(nullable: false, identity: true),
                        CommunityName = c.String(),
                    })
                .PrimaryKey(t => t.CommunityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Communities");
        }
    }
}
