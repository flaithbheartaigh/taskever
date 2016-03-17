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
    [Trait("UserAuthentication", "Logout")]
    public class Logout : TaskeverWebApplicationTest
    {
        LoginPage loginPage;
        IndexPage indexPage;
        public Logout(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
            //driver.Url = "http://localhost:11282/Account/Logout";

            loginPage = new LoginPage(driver);
            indexPage = new IndexPage(driver);

            loginPage.Browse();

            loginPage.EmailAddress = "admin@aspnetboilerplate.com";
            loginPage.Password = "123qwe";

            loginPage.Login();
            
            WaitForUrlChange(driver.Url);
            WaitForReady();
            // check redirected to index
        }

        [Fact(DisplayName = "Should be redirected to the login page")]
        public void should_be_redirected_to_the_login_page()
        {
            indexPage.Logout.Click();
            WaitForUrlChange("http://localhost:11282/Account/Logout");

            driver.Url.ShouldBe(loginPage.Url);
        }
    }
}
