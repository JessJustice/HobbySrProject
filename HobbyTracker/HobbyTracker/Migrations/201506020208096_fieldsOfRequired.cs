namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldsOfRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "TextInput", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "ItemName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ItemName", c => c.String());
            AlterColumn("dbo.Comments", "TextInput", c => c.String());
        }
    }
}
