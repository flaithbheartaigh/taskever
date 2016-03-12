using Abp.Domain.Policies;
using Abp.Authorization.Users;
using Taskever.Security.Users;

namespace Taskever.Security.Users
{
    public interface ITaskeverUserPolicy : IPolicy
    {
        bool CanSeeProfile(TaskeverUser requesterUser, TaskeverUser targetUser);
    }
}
