using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance.Tasks
{
    [Trait("Tasks", "Work on task")]
    public class WorkOnTask : TaskeverWebApplicationTest
    {
        public WorkOnTask(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName = "Updated status is displayed")]
        public void updated_status_is_displayed()
        {
            NotYetImplemented();
        }
    }
}
