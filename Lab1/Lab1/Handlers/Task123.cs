using System.Web;

namespace Lab1.Handlers
{
    public class Task123 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var parameterA = context.Request.Params["ParmA"];
            var parameterB = context.Request.Params["ParmB"];

            context.Response.Write($"{context.Request.HttpMethod}-Http-NVV: ParmA = {parameterA}, ParmB = {parameterB}");
        }

        public bool IsReusable => true;
    }
}