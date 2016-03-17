using System.Reflection;

using Abp.Dependency;
using Abp.Modules;
using Abp.Zero.EntityFramework;

//using Taskever;

namespace Taskever.Infrastructure.EntityFramework
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(TaskeverCoreModule))]
    public class TaskeverDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            base.Initialize();

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}