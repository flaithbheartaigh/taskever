using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance.FriendsSystem
{
    [Trait("Friends", "Add with unknown email")]
    public class AddFriendWithUnknownEmail : TaskeverWebApplicationTest
    {
        public AddFriendWithUnknownEmail(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName = "Displays cannot find email address message")]
        public void displays_cannot_find_email_address_message()
        {
            NotYetImplemented();
        }
    }

}
