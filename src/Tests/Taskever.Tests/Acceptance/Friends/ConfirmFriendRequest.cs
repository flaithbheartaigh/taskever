using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance.FriendsSystem
{
    [Trait("Friends", "Confirm Friend Request")]
    public class ConfirmFriendRequest : TaskeverWebApplicationTest
    {
        public ConfirmFriendRequest(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName = "Adds friend to friends list")]
        public void adds_friend_to_friends_list()
        {
            NotYetImplemented();
        }

        [Fact(DisplayName = "Removes target 'Frienship Request'")]
        public void removes_target_friendship_requests()
        {
            NotYetImplemented();
        }

        [Fact(DisplayName = "Removes Request from source 'Sent Requests'")]
        public void removes_request_from_source_sent_requests()
        {
            NotYetImplemented();
        }
    }
}
