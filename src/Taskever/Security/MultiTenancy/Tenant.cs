using Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations.Schema;
using Taskever.Security.Users;

namespace Taskever.Security.MultiTenancy
{
    [Table("AbpTenants")]
    public class Tenant : AbpTenant<Tenant, TaskeverUser>
    {

    }
}