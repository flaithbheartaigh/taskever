namespace Taskever.Infrastructure.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Heirarchy : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AppActivities", "ActivityType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppActivities", "ActivityType", c => c.Int(nullable: false));
        }
    }
}
