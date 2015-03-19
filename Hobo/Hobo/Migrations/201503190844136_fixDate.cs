namespace Hobo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Birthdate", c => c.Int(nullable: false));
        }
    }
}
