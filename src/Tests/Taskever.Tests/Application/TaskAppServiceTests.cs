using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.UI;

using Taskever.Test;
using Taskever.Tasks;
using Taskever.Users;
using Taskever.Infrastructure.EntityFramework;

using Xunit;
using Xunit.Abstractions;

using Shouldly;

namespace Taskever.Tests.Tasks
{
    [Trait("Service Tests", "TaskAppService")]
    public class TaskAppServiceTests : TaskeverTestBase
    {
        private readonly ITaskAppService _taskAppService;
        private readonly ITaskeverUserAppService _userAppService;
        private readonly ITestOutputHelper output;

        public TaskAppServiceTests(ITestOutputHelper output)
        {
            this.output = output;

            this._taskAppService = Resolve<ITaskAppService>();
            this._userAppService = Resolve<ITaskeverUserAppService>();
        }

        [Fact]
        public void Should_Have_Users()
        {
            output.WriteLine("User Count: {0}", _userAppService.GetAllUsers().Count);
            
            _userAppService.GetAllUsers().Count.ShouldBeGreaterThan(0);


            var user = _userAppService.GetAllUsers()[0];
            output.WriteLine("User[0] id: {0}, email {1}", user.Id, user.EmailAddress);
        }

        [Fact]
        public void Should_Get_Test_Events()
        {
            // todo: rework wth UsingDd and Effort
            _taskAppService.CreateTask(new Taskever.Tasks.Dto.CreateTaskInput { Task = new Taskever.Tasks.Dto.TaskDto { Title = "Taskever.Tests", Description = "Test.Tests", AssignedUserId = 2 } });
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Get_Test_Events_Async()
        {            
            await _taskAppService.CreateTaskAsync(new Taskever.Tasks.Dto.CreateTaskInput{ Task = new Taskever.Tasks.Dto.TaskDto{ Title="Taskever.Tests", Description="Taskever.Tests", AssignedUserId = 2}});
        }
    }
}
