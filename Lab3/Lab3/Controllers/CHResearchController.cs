using System;
using System.Web.Mvc;
using System.Web.UI;

namespace Lab3.Controllers
{
    public class CHResearchController : Controller
    {
        static int a = 0;
        [HttpGet]
        [OutputCache(Duration = 5, Location = OutputCacheLocation.Any)]
        public ActionResult AD()
        {
            a++;
            string currentTime = DateTime.Now.TimeOfDay.ToString();
            return Content($"AD:GET - a = {a} | {currentTime}");
        }


        [HttpPost]
        [OutputCache(Duration = 7, Location = OutputCacheLocation.Any, VaryByParam ="x;y")]
        public ActionResult AP(int x , int y)
        {
            string currentTime = DateTime.Now.TimeOfDay.ToString();
            return Content($"AP:POST - x = {x}, y = {y} | {currentTime}");
        }
    }
}