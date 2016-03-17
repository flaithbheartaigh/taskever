using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Xunit;
using Xunit.Abstractions;

namespace Taskever.Tests.Acceptance
{
    public abstract class AbpWebApplicationTest : WebTest, IDisposable, IAssemblyFixture<IISExpress>
    {
        protected IISExpress iisexpress;
        protected readonly ITestOutputHelper output;

        public abstract string IISWebApplicationName
        {
            get;
        }

        public AbpWebApplicationTest(ITestOutputHelper output, IISExpress iisexpress)
            : base(output)
        {
            this.iisexpress = iisexpress;
            
            iisexpress.Start(IISWebApplicationName);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
