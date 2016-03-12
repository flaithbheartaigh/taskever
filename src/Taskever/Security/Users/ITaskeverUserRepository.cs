using Abp.Domain.Repositories;
using Abp.Authorization.Users;

namespace Taskever.Security.Users
{
    public interface ITaskeverUserRepository: IRepository<TaskeverUser, long>
    {

    }
}
