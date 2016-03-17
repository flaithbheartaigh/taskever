using System;

using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions;

using Shouldly;
using System.Threading;

namespace Taskever.Tests.Acceptance
{
    [Trait("Google", "Check web connection")]
    public class GooglePingTests : WebTest
    {
        public GooglePingTests(ITestOutputHelper output):base(output)
        {
        }

        [Fact(DisplayName = "Ping Google")]
        public void Google_Should_Have_Results_For_Test()
        {
            driver.Url = "http://www.google.ie";
            var searchBox = driver.FindElement(By.Id("lst-ib"));

            searchBox.SendKeys("Test");

            driver.FindElement(By.Name("btnG")).Submit();

            //Todo: fix!!!
            Thread.Sleep(1000);
            //WaitForReady();

            var elements = driver.FindElements(By.ClassName("g"));
            elements.Count.ShouldBe(10);

            foreach( IWebElement element in elements)
            {
                this.output.WriteLine("***element***:{0}", element.Text);
            }
        }
    }
}
