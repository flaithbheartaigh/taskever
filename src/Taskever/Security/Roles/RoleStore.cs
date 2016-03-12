using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Taskever.Security.MultiTenancy;
using Taskever.Security.Users;

namespace Taskever.Security.Roles
{
    public class RoleStore : AbpRoleStore<Tenant, TaskeverRole, TaskeverUser>
    {
        public RoleStore(
            IRepository<TaskeverRole> roleRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository)
        {
        }
    }
}