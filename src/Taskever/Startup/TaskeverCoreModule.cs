using System.Reflection;

using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Logging;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;

using Castle.Core.Logging;

using Taskever.Localization.Resources;
using Taskever.Security.Roles;
using Taskever.Security.Users;
using Taskever.Utils.Mail;

namespace Taskever.Startup
{
    [DependsOn(typeof(AbpZeroCoreModule))] 
    public class TaskeverCoreModule : AbpModule
    {
        ILogger log;

        public override void PreInitialize()
        {
            // ??Required??
            Configuration.MultiTenancy.IsEnabled = false;

            Configuration.Settings.Providers.Add<EmailSettingDefinitionProvider>();

            // Working??
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Admin, MultiTenancySides.Host));
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Admin, MultiTenancySides.Tenant));
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Member, MultiTenancySides.Tenant));

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    TaskeverConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Taskever.Localization.Source"
                        )
                    )
                );

            Clock.Provider = new UtcClockProvider();
        }

        public override void Initialize ( )
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Localization.Sources.Add(new TaskeverLocalizationSource());
        }
    }
}
