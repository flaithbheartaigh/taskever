using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Xunit.Abstractions;
using Xunit;

namespace Taskever.Tests.Acceptance
{
    public abstract class WebTest : IDisposable
    {
        protected IWebDriver driver;
        protected ITestOutputHelper output;

        public WebTest(ITestOutputHelper output)
        {
            this.output = output;
            this.driver = new ChromeDriver();
        }

        protected void WaitForReady()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(drv => (bool)((IJavaScriptExecutor)drv)
                .ExecuteScript("return {jQuery.active||0} == 0"));
        }

        protected void NotYetImplemented()
        {
            Assert.True(false, "Test is not implemented yet!");
        }

        protected void WaitForUrlChange()
        {
            WaitForUrlChange(driver.Url);
        }

        protected void WaitForUrlChange(string url)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(drv =>
            {
                var pageUrl = (String)((IJavaScriptExecutor)drv).ExecuteScript(String.Format("return window.location.href", url));
                return pageUrl != url;
            }
            );
        }

        public virtual void Dispose()
        {
            driver.Close();
        }
    }
}
