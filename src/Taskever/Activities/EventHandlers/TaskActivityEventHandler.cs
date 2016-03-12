using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Taskever.Security.Users;
using Taskever.Tasks;
using Taskever.Tasks.Events;

namespace Taskever.Activities.EventHandlers
{
    public class TaskActivityEventHandler : 
        IEventHandler<EntityCreatedEventData<Task>>, 
        IEventHandler<TaskCompletedEventData>,
        ITransientDependency
    {
        private readonly IActivityService _activityService;
        private readonly IRepository<TaskeverUser, long> _userRepository;

        public TaskActivityEventHandler(IActivityService activityService, IRepository<TaskeverUser, long> userRepository)
        {
            _activityService = activityService;
            _userRepository = userRepository;
        }

        public void HandleEvent(EntityCreatedEventData<Task> eventData)
        {
            var activity = new CreateTaskActivity
                           {
                               CreatorUserId = eventData.Entity.CreatorUserId.Value,
                               AssignedUserId = eventData.Entity.AssignedUserId.Value,
                               TaskId = eventData.Entity.Id
                           };

            _activityService.AddActivity(activity);
        }

        public void HandleEvent(TaskCompletedEventData eventData)
        {
            _activityService.AddActivity(
                    new CompleteTaskActivity
                    {
                        AssignedUserId = eventData.Entity.AssignedUserId.Value,
                        TaskId = eventData.Entity.Id
                    });
        }
    }
}
