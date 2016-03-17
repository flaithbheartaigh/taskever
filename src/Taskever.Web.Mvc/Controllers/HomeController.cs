using System.Web.Mvc;
using Abp.Authorization;
using Abp.Web.Mvc.Authorization;

namespace Taskever.Web.Mvc.Controllers
{
    public class HomeController : TaskeverController
    {
        [AbpMvcAuthorize]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
