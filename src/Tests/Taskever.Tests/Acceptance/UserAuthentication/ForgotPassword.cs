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
    [Trait("UserAuthentication", "ForgotPassword")]
    public class ForgotPassword : TaskeverWebApplicationTest
    {
        LoginPage loginPage;
        public ForgotPassword(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
            loginPage = new LoginPage(driver);
            loginPage.Browse();
        }

        [Fact(DisplayName = "Modal popup should be visible")]
        public void modal_popup_should_be_visible()
        {
            loginPage.ForgotPassword.Click();
            WaitForReady();

            loginPage.ForgotPasswordModal.Displayed.ShouldBeTrue();
        }

        // break from pattern, setup inside method rather than in constructor
        [Fact(DisplayName = "Entering email address should email user")]
        public void Entering_email_address_should_email_user()
        {
            // loginPage.
        }
    }
}
