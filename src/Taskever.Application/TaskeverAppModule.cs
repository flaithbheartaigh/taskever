using System.Reflection;

using Abp.Dependency;
using Abp.Modules;

using Taskever.Mapping;

namespace Taskever
{
    [DependsOn(typeof(TaskeverCoreModule))]
    public class TaskeverAppModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            
            TaskeverDtoMapper.Map();
            UserDtosMapper.Map();
        }
    }
}