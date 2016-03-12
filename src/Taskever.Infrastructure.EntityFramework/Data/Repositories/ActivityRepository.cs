using Abp.EntityFramework;
//using Abp.Domain.Repositories.EntityFramework;
using Abp.EntityFramework.Repositories;
using Taskever.Activities;

namespace Taskever.Infrastructure.EntityFramework.Data.Repositories.NHibernate
{
    public class ActivityRepository : TaskeverEfRepositoryBase<Activity, long>, IActivityRepository
    {
        public ActivityRepository(IDbContextProvider<TaskeverDbContext> context)
            :base(context)
        {

        }
    }
}