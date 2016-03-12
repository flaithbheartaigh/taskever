namespace Taskever.Infrastructure.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppFriendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        FriendUserId = c.Long(nullable: false),
                        PairFriendshipId = c.Int(nullable: false),
                        FollowActivities = c.Boolean(nullable: false),
                        CanAssignTask = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastVisitTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.FriendUserId, cascadeDelete: false)
                .ForeignKey("dbo.AppFriendships", t => t.PairFriendshipId)
                .ForeignKey("dbo.AbpUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FriendUserId)
                .Index(t => t.PairFriendshipId);
            
            CreateTable(
                "dbo.AppTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AssignedUserId = c.Long(),
                        Priority = c.Byte(nullable: false),
                        Privacy = c.Byte(nullable: false),
                        State = c.Byte(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.AssignedUserId)
                .Index(t => t.AssignedUserId);
            
            CreateTable(
                "dbo.AppActivities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AssignedUserId = c.Long(nullable: false),
                        TaskId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        ActivityType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.AssignedUserId, cascadeDelete: true)
                .ForeignKey("dbo.AppTasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId, cascadeDelete: false)
                .Index(t => t.AssignedUserId)
                .Index(t => t.TaskId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "dbo.AppUserFollowedActivities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsActor = c.Boolean(nullable: false),
                        IsRelated = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        Activity_Id = c.Long(),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppActivities", t => t.Activity_Id)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .Index(t => t.Activity_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserFollowedActivities", "User_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.AppUserFollowedActivities", "Activity_Id", "dbo.AppActivities");
            DropForeignKey("dbo.AppActivities", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AppActivities", "TaskId", "dbo.AppTasks");
            DropForeignKey("dbo.AppActivities", "AssignedUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AppTasks", "AssignedUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AppFriendships", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AppFriendships", "PairFriendshipId", "dbo.AppFriendships");
            DropForeignKey("dbo.AppFriendships", "FriendUserId", "dbo.AbpUsers");
            DropIndex("dbo.AppUserFollowedActivities", new[] { "User_Id" });
            DropIndex("dbo.AppUserFollowedActivities", new[] { "Activity_Id" });
            DropIndex("dbo.AppActivities", new[] { "CreatorUserId" });
            DropIndex("dbo.AppActivities", new[] { "TaskId" });
            DropIndex("dbo.AppActivities", new[] { "AssignedUserId" });
            DropIndex("dbo.AppTasks", new[] { "AssignedUserId" });
            DropIndex("dbo.AppFriendships", new[] { "PairFriendshipId" });
            DropIndex("dbo.AppFriendships", new[] { "FriendUserId" });
            DropIndex("dbo.AppFriendships", new[] { "UserId" });
            DropTable("dbo.AppUserFollowedActivities");
            DropTable("dbo.AppActivities");
            DropTable("dbo.AppTasks");
            DropTable("dbo.AppFriendships");
        }
    }
}
