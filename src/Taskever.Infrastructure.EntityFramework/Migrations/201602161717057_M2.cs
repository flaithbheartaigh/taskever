namespace Taskever.Infrastructure.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppActivities", "ActivityType", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppActivities", "ActivityType", c => c.Int(nullable: false));
        }
    }
}
