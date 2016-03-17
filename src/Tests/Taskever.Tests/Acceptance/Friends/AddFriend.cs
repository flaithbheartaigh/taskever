using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance.FriendsSystem
{
    [Trait("Friends", "Add friend")]
    public class AddFriend : TaskeverWebApplicationTest
    {
        public AddFriend(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName = "Shows up in 'Sent Requests'")]
        public void shows_up_in_sent_requests()
        {
            NotYetImplemented();
        }

        [Fact(DisplayName = "Shows up in target 'Friend Requests'")]
        public void shows_up_in_target_friend_requests()
        {
            NotYetImplemented();
        }
    }
}
