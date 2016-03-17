using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance.Tasks
{
    [Trait("Tasks", "Edit Task")]
    public class EditTask : TaskeverWebApplicationTest
    {
        public EditTask(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName = "Updated details are displayed")]
        public void updated_details_are_displayed()
        {
            NotYetImplemented();
        }
    }
}
