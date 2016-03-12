using Abp.Mapping;
using Abp.Users.Dto;

using Taskever.Activities;
using Taskever.Activities.Dto;
using Taskever.Friendships;
using Taskever.Friendships.Dto;
using Taskever.Tasks;
using Taskever.Tasks.Dto;

namespace Taskever.Mapping
{
    public static class TaskeverDtoMapper
    {
        public static void Map()
        {
            AutoMapExtensions.Configure(
                c =>
                {
                    // Original Code
                    //AutoMapper.Mapper.Configuration
                    //    .CreateMap<Activity, ActivityDto>()
                    //    .Include<CreateTaskActivity, CreateTaskActivityDto>()
                    //    .Include<CompleteTaskActivity, CompleteTaskActivityDto>();
                    //
                    // With Type check in OnModelCreating on the Activity Type

                    c.CreateMap<Task, TaskDto>().ReverseMap();
                    c.CreateMap<Task, TaskWithAssignedUserDto>().ReverseMap();
                    c.CreateMap<Friendship, FriendshipDto>().ReverseMap();

                    c.CreateMap<CreateTaskActivity, ActivityDto>()
                        .ConstructUsing(
                            (CreateTaskActivity x) => 
                            {
                                CreateTaskActivityDto dto = new CreateTaskActivityDto();
                                dto.ActivityType = ActivityType.CreateTask;
                                dto.Task = x.Task.MapTo<TaskDto>();
                                dto.CreatorUser = x.CreatorUser.MapTo<UserDto>();
                                dto.AssignedUser = x.AssignedUser.MapTo<UserDto>();
                                dto.Id = x.Id;
                                dto.CreationTime = x.CreationTime;

                                return dto; 
                            }
                        );

                    c.CreateMap<CompleteTaskActivity, ActivityDto>()
                        .ConstructUsing(
                            (CompleteTaskActivity x) =>
                            {
                                CompleteTaskActivityDto dto = new CompleteTaskActivityDto();
                                dto.ActivityType = ActivityType.CreateTask;
                                dto.Task = x.Task.MapTo<TaskDto>();
                                dto.AssignedUser = x.AssignedUser.MapTo<UserDto>();
                                dto.Id = x.Id;
                                dto.CreationTime = x.CreationTime;

                                return dto;
                            }
                        );

                    c.CreateMap<UserFollowedActivity, UserFollowedActivityDto>();
                }
            );
        }
    }
}
