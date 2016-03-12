using Abp.Authorization.Roles;
using System.ComponentModel.DataAnnotations.Schema;
using Taskever.Security.MultiTenancy;
using Taskever.Security.Users;

namespace Taskever.Security.Roles
{
    [Table("AbpRoles")]
    public class TaskeverRole : AbpRole<Tenant, TaskeverUser>
    {
        //no additional field yet
    }
}