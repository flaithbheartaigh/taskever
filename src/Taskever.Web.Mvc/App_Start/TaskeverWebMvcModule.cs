using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Abp.Authorization.Users;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Logging;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.Mvc.Resources;

using Castle.Core.Logging;

using Taskever.Activities;
using Taskever.Infrastructure.EntityFramework;
using Taskever.Security.Roles;
using Taskever.Security.Users;

using Taskever.Tasks;

namespace Taskever.Web.Mvc
{
    [DependsOn(typeof(TaskeverDataModule), typeof(TaskeverAppModule), typeof(TaskeverWebApiModule), typeof(AbpWebMvcModule))]
    public class TaskeverWebMvcModule : AbpModule
    {
        ILogger logger;

        public override void PreInitialize()
        {
            base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Check into this
            WebResourceHelper.ExposeEmbeddedResources("Taskever/Er/Test", typeof(TaskAppService).Assembly, "Taskever.Test");
            // WebResourceHelper.ExposeEmbeddedResources("Taskever/Er/Test", typeof(TaskAppService).Assembly, "Taskever.Test");

            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}