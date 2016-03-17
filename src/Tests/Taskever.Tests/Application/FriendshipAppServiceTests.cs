using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Taskever.Friendships;
using Taskever.Tasks;

using Taskever.Test;
using Xunit.Abstractions;

namespace Taskever.Tests.Application
{
    public class FriendshipAppServiceTests : TaskeverTestBase
    {
        private readonly FriendshipAppService _taskAppService;
        private readonly ITestOutputHelper output;

        public FriendshipAppServiceTests(ITestOutputHelper output)
        {
        }
    }
}
