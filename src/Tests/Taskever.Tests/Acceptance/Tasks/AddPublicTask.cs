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
    public class AddPublicTask : TaskeverWebApplicationTest
    {
        public AddPublicTask(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName = "Show up in public task list")]
        public void shows_up_in_public_task_list()
        {
            NotYetImplemented();
        }
    }
}
