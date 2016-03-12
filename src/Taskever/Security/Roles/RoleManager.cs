using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using Taskever.Security.MultiTenancy;
using Taskever.Security.Users;

namespace Taskever.Security.Roles
{
    public class RoleManager : AbpRoleManager<Tenant, TaskeverRole, TaskeverUser>
    {
        public RoleManager(
            RoleStore store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                cacheManager)
        {
        }
    }
}