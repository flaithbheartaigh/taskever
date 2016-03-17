using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance.Tasks
{
    [Trait("Tasks", "Add private task")]
    public class AddPrivateTask : TaskeverWebApplicationTest
    {
        public AddPrivateTask(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName = "Does not show up in public task list")]
        public void does_not_show_up_in_public_task_list()
        {
            NotYetImplemented();
        }
    }
}
