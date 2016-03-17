using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance
{
    [Trait("TaskSystem", "Task System")]
    public class TaskSystemUiTests: AbpWebApplicationTest
    {
        // these are in the iis app hosts config file
        private string AppName = "Taskever.Web.Mvc";
        private string AppURL  = "http://localhost:11282/";

        public override string IISWebApplicationName
        {
            get
            {
                return AppName;
            }
        }

        public TaskSystemUiTests(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact]
        public void new_task_shows_up_in_tasklist()
        {
            Assert.True(false, "Not Yet Implemented!");
        }

        [Fact]
        public void new_private_task_shows_in_tasklist()
        {
            Assert.True(false, "Not Yet Implemented!");
        }

        [Fact]
        public void set_task_as_working_on_adds_activity()
        {
            Assert.True(false, "Not Yet Implemented!");
        }
    }
}
