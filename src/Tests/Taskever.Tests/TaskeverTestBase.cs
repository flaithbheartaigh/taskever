using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.DynamicFilters;

using Abp.Collections;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Runtime.Session;
using Abp.TestBase;

using Taskever.Infrastructure.EntityFramework;
using Taskever.Infrastructure.EntityFramework.Data;
using Taskever.Infrastructure.EntityFramework.Data.Repositories;
using Taskever.Infrastructure.EntityFramework.Migrations.SeedData;

using Taskever.Security.MultiTenancy;
using Taskever.Security.Users;

using Taskever.Test.Data;

namespace Taskever.Test
{
    public abstract class TaskeverTestBase : AbpIntegratedTestBase
    {
        static TaskeverTestBase()
        {
        }

        protected TaskeverTestBase()
        {
            //Seed initial data
            UsingDbContext(context => { new InitialDataBuilder(context).Build(); new TestDataBuilder(context).Build(); });

            LoginAsHostAdmin();
        }

        protected override void PreInitialize()
        {
            base.PreInitialize();

            //DbConnection conn = Effort.DbConnectionFactory.CreatePersistent("Taskever");
            //conn.StateChange += conn_StateChange;
            //Fake DbConnection using Effort!
            //LocalIocManager.IocContainer.Register(
            //    Component.For<DbConnection>()
            //    .Instance(conn)
            //    .LifestyleSingleton()
            //);
        }

        void conn_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            int i = 0;
        }

        protected override void AddModules(ITypeList<AbpModule> modules)
        {
            base.AddModules(modules);

            //Adding testing modules. Depended modules of these modules are automatically added.
            modules.Add<TaskeverAppModule>();
            modules.Add<TaskeverDataModule>();
        }

        public void UsingDbContext(Action<TaskeverDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<TaskeverDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                context.SaveChanges();
            }
        }

        public async Task UsingDbContext(Func<TaskeverDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<TaskeverDbContext>())
            {
                context.DisableAllFilters();
                await action(context);
                await context.SaveChangesAsync();
            }
        }

        public T UsingDbContext<T>(Func<TaskeverDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<TaskeverDbContext>())
            {
                context.DisableAllFilters();
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected void LoginAsHostAdmin()
        {
            //LoginAsHost(User.AdminUserName);
            LoginAsHost("admin");
        }

        protected void LoginAsDefaultTenantAdmin()
        {
            //LoginAsTenant(Tenant.DefaultTenantName, User.AdminUserName);
            LoginAsTenant("admin", "admin");
        }

        protected void LoginAsHost(string userName)
        {
            //AbpSession.TenantId = null;
            Resolve<IMultiTenancyConfig>().IsEnabled = false;

            // AbpSession.MultiTenancySide = Abp.MultiTenancy.MultiTenancySides.Host;

            var user = UsingDbContext(context => context.Users.FirstOrDefault(u => /* u.TenantId == AbpSession.TenantId && */ u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for host.");
            }
            AbpSession.UserId = user.Id;
        }

        protected void LoginAsTenant(string tenancyName, string userName)
        {
            var tenant = UsingDbContext(context => context.Tenants.FirstOrDefault(t => t.TenancyName == tenancyName));
            if (tenant == null)
            {
                throw new Exception("There is no tenant: " + tenancyName);
            }

            AbpSession.TenantId = tenant.Id;

            var user = UsingDbContext(context => context.Users.FirstOrDefault(u => u.TenantId == AbpSession.TenantId && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for tenant: " + tenancyName);
            }

            AbpSession.UserId = user.Id;
        }

        /// <summary>
        /// Gets current user if <see cref="IAbpSession.UserId"/> is not null.
        /// Throws exception if it's null.
        /// </summary>
        protected async Task<TaskeverUser> GetCurrentUserAsync()
        {
            var userId = AbpSession.GetUserId();
            return await UsingDbContext(context => context.Users.SingleAsync(u => u.Id == userId));
        }

        /// <summary>
        /// Gets current tenant if <see cref="IAbpSession.TenantId"/> is not null.
        /// Throws exception if there is no current tenant.
        /// </summary>
        protected async Task<Tenant> GetCurrentTenantAsync()
        {
            var tenantId = AbpSession.GetTenantId();
            return await UsingDbContext(context => context.Tenants.SingleAsync(t => t.Id == tenantId));
        }
    }
}