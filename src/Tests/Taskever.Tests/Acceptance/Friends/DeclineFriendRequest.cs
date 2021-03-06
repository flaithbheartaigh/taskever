﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance.FriendsSystem
{
    // could use inheritance here to avoid 
    //  a little duplication in the tests
    [Trait("Friends", "Decline Friend Request")]
    public class DeclineFriendRequest : TaskeverWebApplicationTest
    {
        public DeclineFriendRequest(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
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
