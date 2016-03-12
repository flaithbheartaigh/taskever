using System;

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

using Abp.Authorization.Users;
using Taskever.Security.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskever.Activities
{
    [Table("AppUserFollowedActivities")]
    public class UserFollowedActivity : Entity<long>, IHasCreationTime
    {
        public virtual TaskeverUser User { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual bool IsActor { get; set; }

        public virtual bool IsRelated { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public UserFollowedActivity()
        {
            CreationTime = DateTime.Now;
        }
    }
}
