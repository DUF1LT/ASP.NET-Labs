using System.Web;

namespace Lab1.Handlers
{
    public class Task123 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var parameterA = context.Request.Params["ParamA"];
            var parameterB = context.Request.Params["ParamB"];

            context.Response.Write($"{context.Request.HttpMethod}-Http-NVV: ParamA = {parameterA}, ParamB = {parameterB}");
        }

        public bool IsReusable => true;
    }
}