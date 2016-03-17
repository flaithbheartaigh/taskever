using System.Reflection;

using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

using Taskever.Activities;
using Taskever.Friendships;

using Taskever.Tasks;
using Taskever.Users;

namespace Taskever.Web
{
    [DependsOn(typeof(AbpWebApiModule), typeof(TaskeverAppModule))]
    public class TaskeverWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            CreateWebApiProxiesForServices();
        }

        private static void CreateWebApiProxiesForServices()
        {
            //TODO: must be able to exclude/include all methods option
            DynamicApiControllerBuilder
                .For<ITaskeverUserAppService>("taskever/user")
                .Build();

            DynamicApiControllerBuilder
                .For<ITaskAppService>("taskever/task")
                .Build(); 

            DynamicApiControllerBuilder
                .For<IFriendshipAppService>("taskever/friendship")
                .Build();

            DynamicApiControllerBuilder
                .For<IUserActivityAppService>("taskever/userActivity")
                .Build();
        }
    }
}