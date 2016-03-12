namespace Taskever.Infrastructure.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppActivities", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppActivities", "Discriminator");
        }
    }
}
