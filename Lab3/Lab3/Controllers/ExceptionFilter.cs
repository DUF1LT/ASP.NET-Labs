using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class ExceptionFilter  : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>ExceptionFilter: OnException</p>");
            var vr = new ViewResult
            {
                ViewName = "Error"
            };
            filterContext.Result = vr;
            filterContext.ExceptionHandled = true;
        }
    }
}