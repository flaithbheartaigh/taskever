using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance
{
    public abstract class TaskeverWebApplicationTest : AbpWebApplicationTest
    {
        // these are in the iis app hosts config file
        private string AppName = "Taskever.Web.Mvc";
        private string AppURL = "http://localhost:11282";

        public override string IISWebApplicationName
        {
            get
            {
                return AppName;
            }
        }

        public TaskeverWebApplicationTest(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
            Site.BaseUrl = AppURL;
        }
    }}
