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
    [Trait("UserAuthentication", "Invalid Login")]
    public class LoginWithInvalidDetails : TaskeverWebApplicationTest
    {
        public LoginPage loginPage;
        public LoginWithInvalidDetails(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
            loginPage = new LoginPage(driver);
            loginPage.Browse();

            loginPage.EmailAddress = "admin@aspnetboilerplate.com";
            loginPage.Password = "123123";
        }

        [Fact(DisplayName = "Displays error in username or password message")]
        public void displays_error_in_username_or_password_message()
        {
            loginPage.Login();

            WaitForReady();

            loginPage.LoginErrorMessage.ShouldContain("Your email address or password is incorrect");
        }
    }

}
