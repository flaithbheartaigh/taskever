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
    [Trait("UserAuthentication", "UnauthenticatedUser")]
    public class UnauthenticatedUser : TaskeverWebApplicationTest
    {
        IndexPage indexPage;
        public UnauthenticatedUser(ITestOutputHelper output, IISExpress issexpress)
            : base(output, issexpress)
        {
            driver.Url = Site.BaseUrl + "/Account/Logout";

            indexPage = new IndexPage(driver);
            indexPage.Browse();
        }

        [Fact(DisplayName = "Should be redirected from home page to login")]
        public void should_be_redirected_from_home_page_to_login()
        {
            //wait for page load??
            driver.Url.ShouldBe(Site.BaseUrl+"/Account/Login");
        }
    }
}
