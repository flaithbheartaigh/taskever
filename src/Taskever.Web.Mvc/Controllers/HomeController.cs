using System.Web.Mvc;
using Abp.Authorization;

namespace Taskever.Web.Mvc.Controllers
{
    [AbpAuthorize]
    public class HomeController : TaskeverController
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
