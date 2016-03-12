using System.Data.Common;
using System.Data.Entity;

using Abp.Zero.EntityFramework;

using Taskever.Activities;
using Taskever.Friendships;
using Taskever.Security.MultiTenancy;
using Taskever.Security.Roles;
using Taskever.Security.Users;
using Taskever.Tasks;

namespace Taskever.Infrastructure.EntityFramework.Data
{
    public class TaskeverDbContext : AbpZeroDbContext<Tenant, TaskeverRole, TaskeverUser>
    {
        public virtual IDbSet<Friendship> Friendships { get; set; }
        public virtual IDbSet<Task> Tasks { get; set; }
        public virtual IDbSet<Activity> Activities { get; set; }
        public virtual IDbSet<UserFollowedActivity> UserFollowedActivities { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public TaskeverDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TaskeverDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TaskeverDbContext since ABP automatically handles it.
         */
        public TaskeverDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            // Configuration.ProxyCreationEnabled = false;
        }

        //This constructor is used in tests
        public TaskeverDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}