using Abp.Mapping;
using Abp.Users.Dto;

using Taskever.Security.Users;

namespace Taskever.Mapping
{
    public static class UserDtosMapper
    {
        public static void Map()
        {
            AutoMapExtensions.Configure(
                 c =>
                 {
                     c.CreateMap<TaskeverUser, UserDto>()
                         .ForMember(
                             user => user.ProfileImage,
                             configuration => configuration.ResolveUsing(
                                 user => user.ProfileImage == null
                                     //TODO: How to implement this?
                                             ? ""
                                             : "ProfileImages/" + user.ProfileImage
                                                  )
                         ).ReverseMap();

                     c.CreateMap<RegisterUserInput, TaskeverUser>();
                     c.CreateMap<TaskeverUser, UserDto>().ReverseMap();
                     c.CreateMap<RegisterUserInput, TaskeverUser>();
                 }
             );
        }
    }
}
