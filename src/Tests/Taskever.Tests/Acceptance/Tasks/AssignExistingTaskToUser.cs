using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance.Tasks
{
    [Trait("Tasks", "Assign existing Task to user")]
    public class AssignExistingTaskToUser : TaskeverWebApplicationTest
    {
        public AssignExistingTaskToUser(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName = "Task appears in assigned users task list")]
        public void task_appears_in_assigned_users_task_list()
        {
            NotYetImplemented();
        }
    }

}
