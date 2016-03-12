using Abp.Domain.Repositories;
using Abp.MultiTenancy;


using Taskever.Editions;
using Taskever.Security.Roles;
using Taskever.Security.Users;

namespace Taskever.Security.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, TaskeverRole, TaskeverUser>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager
            ) : base(
            tenantRepository, 
            tenantFeatureRepository, 
            editionManager)
        {
        }
    }
}