using System;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class AResearchController : Controller
    {
        [ActionFilter]
        public ActionResult AA()
        {
            return Content("AA test\n");
        }

        [ResultFilter]
        public ActionResult AR()
        {
            return Content("AR test\n");
        }

        [ExceptionFilter]
        public ActionResult AE()
        {
            throw new Exception("From AE");
        }
    }
}