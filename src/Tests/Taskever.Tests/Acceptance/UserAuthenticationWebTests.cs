using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Xunit.Abstractions;

using Shouldly;

namespace Taskever.Tests.Acceptance
{

    public class UserAuthenticationTests : AbpWebApplicationTest
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

        public UserAuthenticationTests(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
        }

        [Fact(DisplayName = "Login with Invalid Email Address")]
        private void InvalidEmail()
        {
            driver.Url = "http://localhost:11282/Account/Logout";

            var userName = driver.FindElement(By.Id("LoginEmailAddress"));
            var password = driver.FindElement(By.Id("LoginPassword"));

            userName.SendKeys("Invalidemail");
            password.SendKeys("Not a password");

            var submit = driver.FindElement(By.CssSelector("button[type='submit']"));
            submit.Click();

            var error = driver.FindElement(By.Id("LoginEmailAddress-error"));
            error.Text.ShouldContain("Please enter a valid email address");
        }

        [Fact(DisplayName = "Login with non existant user email")]
        private void InvalidLogin()
        {
            driver.Url = "http://localhost:11282/Account/Logout";

            var userName = driver.FindElement(By.Id("LoginEmailAddress"));
            var password = driver.FindElement(By.Id("LoginPassword"));

            userName.SendKeys("admin@aspnetboilerplate.com");
            password.SendKeys("123123");
            
            var submit = driver.FindElement(By.CssSelector("button[type='submit']"));
            submit.Click();

            WaitForReady();

            var errorModal = driver.FindElement(By.Id("LoginErrorModal"));
            var errorMessage = driver.FindElement(By.Id("LoginErrorMessage"));

            errorMessage.Text.ShouldContain("Your email address or password is incorrect");
        }

        [Fact(DisplayName = "Valid Login")]
        private void ValidLogin()
        {
            driver.Url = "http://localhost:11282/Account/Logout";

            var userName = driver.FindElement(By.Id("LoginEmailAddress"));
            var password = driver.FindElement(By.Id("LoginPassword"));

            userName.SendKeys("admin@aspnetboilerplate.com");
            password.SendKeys("123qwe");

            var submit = driver.FindElement(By.CssSelector("button[type='submit']"));
            submit.Click();

            WaitForUrlChange(driver.Url);

            driver.Url.ShouldBe("http://localhost:11282/");
        }

        [Fact(DisplayName = "Logout")]
        private void Logout()
        {
            Assert.True(false, "Not Yet Implemented!");
        }

        [Fact(DisplayName = "Forgot Password")]
        private void ForgotPassword()
        {
            Assert.True(false, "Not Yet Implemented!");
        }

        [Fact(DisplayName = "Forgot Password - Invalid email account")]
        private void ForgotPassword_InvalidEmail()
        {
            Assert.True(false, "Not Yet Implemented!");
        }

        [Fact(DisplayName = "Registration")]
        private void Registration()
        {
            Assert.True(false, "Not Yet Implemented!");
        }
    }
}