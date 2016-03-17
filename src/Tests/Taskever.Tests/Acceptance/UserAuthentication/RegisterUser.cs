using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

using OpenQA.Selenium;

namespace Taskever.Tests.Acceptance.UserAuthentication
{
    //TODO: ??how to deal with capthca & email??
    [Trait("UserAuthentication", "Register User")]
    public class RegisterUser : TaskeverWebApplicationTest
    {
        RegisterPage registerPage;
        public RegisterUser(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
            registerPage = new RegisterPage(driver);
        }

        [Fact(DisplayName = "Should send email confirmation to user")]
        public void should_send_email_confirmation_to_user()
        {
            // 

            NotYetImplemented();
        }

        private void setRecaptchaValues()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;  
            js.ExecuteScript("document.getElementsByName('recaptcha_challenge_field')[0].setAttribute('value', '03AHJ_Vuv4tV3FrmUHbImL9JPkWJNqs1KDbFdKfG1jhqa2Uhl4U1vzLxXtZMMkZoAHuVCXA1js3GiaaQJ-zqyuledzZP-PEOV-y_Fx87-U6HVu4nh8kfwPzfPU50yEV5oscb20ptwMGR5EEoAtE8dfAlwCVejJtP779upzfAqn_ID5IQJ2F9Nw218')");
            driver.FindElement(By.Name("recaptcha_response_field")).SendKeys("23129555894");
        }
    }
}
