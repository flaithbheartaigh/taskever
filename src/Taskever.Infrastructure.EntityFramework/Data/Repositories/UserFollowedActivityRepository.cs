using System.Collections.Generic;

using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Taskever.Activities;
using System;
using System.Linq;

namespace Taskever.Infrastructure.EntityFramework.Data.Repositories
{
    public class UserFollowedActivityRepository : TaskeverEfRepositoryBase<UserFollowedActivity, long>, IUserFollowedActivityRepository
    {
        public UserFollowedActivityRepository(IDbContextProvider<TaskeverDbContext> context)
            :base(context)
        {

        }

        public IList<UserFollowedActivity> GetActivities(long userId, bool? isActor, long beforeId, int maxResultCount)
        {
            var act = (from item in GetAll() /*Table.Include("User")
                                        .Include("Activity.AssignedUser")
                                        .Include("Activity.Task")
                                        .Include("Activity.Task.AssignedUser")*/
                       where item.User.Id == userId
                       && item.Id < beforeId
                       && item.IsActor == isActor
                       select item).Take(maxResultCount);
            List<UserFollowedActivity> result = act.ToList();
            //act.ToList().
            // manuall
            //result.ForEach(
            //        x =>
            //        {
            //            x.Activity.Task.ToString();
            //        }
            //    );

            return result;

            //var queryBuilder = new StringBuilder();
            //queryBuilder.AppendLine("from " + typeof(UserFollowedActivity).FullName + " as ufa");
            //queryBuilder.AppendLine("inner join fetch ufa.Activity as act");
            //queryBuilder.AppendLine("left outer join fetch act.Task as task");
            //queryBuilder.AppendLine("left outer join fetch act.CreatorUser as cusr");
            //queryBuilder.AppendLine("left outer join fetch act.AssignedUser as ausr");
            //queryBuilder.AppendLine("where ufa.User.Id = :userId and ufa.id < :beforeId");

            //if (isActor.HasValue)
            //{
            //    queryBuilder.AppendLine("and ufa.IsActor = :isActor");
            //}

            //queryBuilder.AppendLine("order by ufa.Id desc");

            //var query = Session
            //    .CreateQuery(queryBuilder.ToString())
            //    .SetParameter("userId", userId)
            //    .SetParameter("beforeId", beforeId);

            //if (isActor.HasValue)
            //{
            //    query.SetParameter("isActor", isActor.Value);
            //}

            //return query
            //    .SetMaxResults(maxResultCount)
            //    .List<UserFollowedActivity>();
        }
    }
}