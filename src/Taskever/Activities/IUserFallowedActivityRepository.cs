using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace Taskever.Activities
{
    public interface IUserFollowedActivityRepository :  IRepository<UserFollowedActivity, long>
    {
        IList<UserFollowedActivity> GetActivities(long userId, bool? isActor, long beforeId, int maxResultCount);
    }
}