using System;
using System.Net;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class ActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p> ActionFilter: OnActionExecuted</p>");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p> ActionFilter: OnActionExecuting</p>");
        }
    }
}