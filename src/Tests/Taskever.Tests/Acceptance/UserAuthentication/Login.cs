using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;
using Shouldly;
using OpenQA.Selenium;

namespace Taskever.Tests.Acceptance.UserAuthentication
{
    [Trait("UserAuthentication", "Valid Login")]
    public class Login : TaskeverWebApplicationTest
    {
        LoginPage loginPage;
        IndexPage indexPage;

        public Login(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
            loginPage = new LoginPage(driver);
            loginPage.Browse();

            loginPage.EmailAddress = "alanflaherty@mail.com";
            loginPage.Password = "123qwe";

            indexPage = new IndexPage(driver);
        }

        [Fact(DisplayName = "Should be on the secure home page")]
        public void should_be_on_the_secure_home_page()
        {
            var submit = driver.FindElement(By.CssSelector("button[type='submit']"));
            submit.Click();

            WaitForUrlChange(driver.Url);

            driver.Url.ShouldBe("http://localhost:11282/");
        }

        [Fact(DisplayName = "Intrim test on main section")]
        public void main_section_test()
        {
            var submit = driver.FindElement(By.CssSelector("button[type='submit']"));
            submit.Click();
            WaitForUrlChange("http://localhost:11282/Account/Login");

            indexPage.MainSection.GetAttribute("data-view").ShouldBe("views/home");

            indexPage.CreateNewTask.Click();
            WaitForReady();
            indexPage.MainSection.GetAttribute("data-view").ShouldBe("views/task/edit");
        }
    }
}
