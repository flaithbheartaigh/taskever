using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Mapping;
using Abp.Users.Dto;

using Taskever.Activities;
using Taskever.Activities.Dto;
using Taskever.Infrastructure.EntityFramework.Data;
using Taskever.Infrastructure.EntityFramework.Data.Repositories;
using Taskever.Mapping;
using Taskever.Security.Users;
using Taskever.Tasks;
using Taskever.Test;

using Xunit;
using Xunit.Abstractions;

using Shouldly;

namespace Taskever.Tests.AutoMap
{
    [Trait("ObjectMapping", "Object Mapping Tests")]
    public class MappingTests : TaskeverTestBase
    {
        private readonly ITestOutputHelper output;

        private readonly TaskeverDbContext _context;
        private readonly IRepository<Activity, long> activitiesRepo;
        private readonly IUnitOfWorkManager _uowManager;

        public MappingTests(ITestOutputHelper output)
        {
            this.output = output;
            this.activitiesRepo = Resolve<IRepository<Activity, long>>();
            this._context = Resolve<TaskeverDbContext>();
            this._uowManager = Resolve<IUnitOfWorkManager>();

            TaskeverDtoMapper.Map();
            UserDtosMapper.Map();
        }

        [Fact]
        public void CreateTaskActivity_From_Database_Should_Not_Be_Of_Type_Activity()
        {
            using (IUnitOfWorkCompleteHandle handle = this._uowManager.Begin())
            {
                Activity activity = activitiesRepo.Load(1);
                activity.ShouldBeAssignableTo<CreateTaskActivity>();

                CreateTaskActivity cta = (CreateTaskActivity)activity;
                cta.Task.ShouldNotBeNull();

                //transaction.Commit();
                handle.Complete();
            }
        }

        [Fact]
        public void CreateTaskActivity_Should_MapTo_DerivedActivityDto()
        {
            TaskeverUser user = new TaskeverUser();
            user.Id = 1;

            Task task = new Task();
            task.Id = 1;
            task.AssignedUser = user;
            task.AssignedUserId = user.Id;
            task.Title = "Title";
            task.Description = "Description";

            CreateTaskActivity act = new CreateTaskActivity();
            act.Id = 1;
            act.AssignedUser = user;
            act.AssignedUserId = user.Id;

            act.Task = task;
            act.TaskId = task.Id;

            act.MapTo<ActivityDto>().ShouldBeAssignableTo<CreateTaskActivityDto>();
            
            UserFollowedActivity ufa = new UserFollowedActivity();
            ufa.Activity = act;
            ufa.Id = 1;
            ufa.IsActor = true;
            ufa.User = user;

            //act
            UserFollowedActivityDto dto = ufa.MapTo<UserFollowedActivityDto>();

            //assert
            dto.Activity.ShouldBeAssignableTo<CreateTaskActivityDto>();
        }
    }
}
