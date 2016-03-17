using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;
using Shouldly;

namespace Taskever.Tests.Acceptance.UserAuthentication
{
    [Trait("UserAuthentication", "ForgotPasswordInvalidEmail")]
    public class ForgotPasswordUnknownEmail : TaskeverWebApplicationTest
    {
        LoginPage loginPage;

        public ForgotPasswordUnknownEmail(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
            loginPage = new LoginPage(driver);
            loginPage.Browse();
        }

        [Fact(DisplayName = "Should display unknown user message")]
        public void should_display_unknown_user_message()
        {
            loginPage.ForgotPassword.Click();
            WaitForReady();
            loginPage.ForgotPasswordEmailAddress.Displayed.ShouldBeTrue();
            loginPage.ForgotPasswordEmailAddress.SendKeys("unknownuser@test.com");
            loginPage.ForgotPasswordSubmit.Click();
        }
    }
}
