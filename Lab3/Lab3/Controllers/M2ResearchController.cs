using System.Web.Mvc;

namespace Lab3.Controllers
{
    [RoutePrefix("it")]
    public class M2ResearchController : Controller
    {
        [Route("{n:int}/{str}"), HttpGet]
        public ActionResult M01(int n, string str)
        {
            return Content($"GET:M01: {n}/{str}");
        }

        [Route("{b:bool}/{letters}"), AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult M02(bool b, string letters)
        {
            return Content($"{HttpContext.Request.HttpMethod}:M02 /{b}/{letters}");
        }

        [Route("{f:float}/{str:minlength(2):maxLength(5)}"), AcceptVerbs(HttpVerbs.Get | HttpVerbs.Delete)]
        public ActionResult M03(float f, string str)
        {
            return Content($"{HttpContext.Request.HttpMethod}:M03 /{f}/{str}");
        }

        [Route("{letters:minlength(3):maxLength(4)}/{n:int:min(100):max(200)}"), HttpPut]
        public ActionResult M04(string letters, int n)
        {
            return Content($"{HttpContext.Request.HttpMethod}:M04 /{letters}/{n}");
        }

        [Route(@"{mail:regex(^\w+@\w+.\w+$)}"), HttpPost]
        public ActionResult M05(string mail)
        {
            return Content($"{HttpContext.Request.HttpMethod}:M04 /{mail}");
        }

    }
}