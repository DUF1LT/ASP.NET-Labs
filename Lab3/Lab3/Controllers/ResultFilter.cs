using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class ResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>ResultFr:OnResultExecuted</p>");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>ResultFr:OnResultExecuting</p>");
        }
    }
}