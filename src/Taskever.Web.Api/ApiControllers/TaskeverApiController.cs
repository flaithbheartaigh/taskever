using System.Text;
using Abp.WebApi.Controllers;

namespace Taskever.Web.ApiControllers
{
    public class TaskeverApiController : AbpApiController
    {
        public TaskeverApiController()
        {
            LocalizationSourceName = "Taskever"; //TODO: Make constant!
        }

        protected override System.Web.Http.Results.JsonResult<T> Json<T>(T content, Newtonsoft.Json.JsonSerializerSettings serializerSettings, Encoding encoding)
        {
            return base.Json<T>(content, serializerSettings, encoding);
        }
    }
}
