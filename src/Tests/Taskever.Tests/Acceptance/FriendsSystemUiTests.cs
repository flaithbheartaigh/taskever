using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance
{
    public class FriendsSystemUiTests: AbpWebApplicationTest
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

        public FriendsSystemUiTests(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName="Add New Friend - Shows up in 'Sent Requests'")]
        public void add_new_friend_shows_up_in_sent_requests()
        {
            Assert.True(false, "Not Yet Implemented!");
        }

        [Fact(DisplayName = "Add New Friend - Shows up in target 'Friend Requests'")]
        public void add_new_friend_shows_up_in_friend_requests()
        {
            Assert.True(false, "Not Yet Implemented!");
        }


        [Fact(DisplayName = "Confirm Friend Request - Adds friend")]
        public void confirm_friend_request_adds_friend()
        {
            Assert.True(false, "Not Yet Implemented!");
        }

        [Fact(DisplayName = "Confirm Friend Request - Removes source 'Sent Requests'")]
        public void confirm_friend_request_removes_from_source_sent_requests()
        {
            Assert.True(false, "Not Yet Implemented!");
        }
        
        [Fact(DisplayName = "Confirm Friend Request - Removes target 'Frienship Request'")]
        public void confirm_friend_request_removes_from_target_friendship_requests()
        {
            Assert.True(false, "Not Yet Implemented!");
        }
    }
}
