using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class CResearchController : Controller
    {
        [ActionName("C01")]
        [AcceptVerbs("get", "post")]
        public ActionResult C01()
        {
            ViewBag.Request = Request;
            ViewBag.Method = Request.HttpMethod;

            return View();
        }

        [ActionName("C02")]
        [AcceptVerbs("get", "post")]
        public ActionResult C02()
        {
            ViewBag.Request = Request;
            ViewBag.Response = Response;
            ViewBag.Method = Request.HttpMethod;

            return View();
        }
    }
}