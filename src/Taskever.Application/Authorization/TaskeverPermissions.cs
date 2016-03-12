using System.Collections.Generic;
using System.Linq;

using Abp.Authorization;
using Abp.Localization;

using Taskever.Localization.Resources;

namespace Taskever.Authorization
{
    public class TaskeverPermissions : IPermissionManager
    {
        public const string CreateTask = "Taskever.Tasks.Create";
        private static readonly Permission[] AllPermissionsDefinition;

        static TaskeverPermissions()
        {
            AllPermissionsDefinition =
                new[]
                {
                    new Permission(
                        CreateTask,
                        new LocalizableString("CreateTaskPermissionDisplayName", TaskeverLocalizationSource.SourceName)
                        )
                };
        }

        public IReadOnlyList<Permission> GetAllPermissions(Abp.MultiTenancy.MultiTenancySides multiTenancySides)
        {
            return AllPermissionsDefinition;
        }

        public IReadOnlyList<Permission> GetAllPermissions(bool tenancyFilter = true)
        {
            return AllPermissionsDefinition;
        }

        public Permission GetPermission(string name)
        {
            Permission p = GetPermissionOrNull(name);

            if (p == null)
                throw new Exceptions.TaskeverException(string.Format("Permission '{0}' not found", name));

            return p;
        }

        public Permission GetPermissionOrNull(string name)
        {
            Permission p = (from item in AllPermissionsDefinition
                            where item.Name == name
                            select item).FirstOrDefault<Permission>();

            return p;
        }
    }
}
