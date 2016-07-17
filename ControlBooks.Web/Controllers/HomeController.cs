using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace ControlBooks.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ControlBooksControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}