using System;
using System.Web;

namespace Lab1.Handlers
{
    public class Task6 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var method = context.Request.HttpMethod;

            switch (method)
            {
                case "GET":
                {
                    var fileName = AppDomain.CurrentDomain.BaseDirectory + "Views\\task6.html";
                    context.Response.WriteFile(fileName);
                    break;
                }
                case "POST":
                {
                    var x = context.Request.Params["X"];
                    var y = context.Request.Params["Y"];

                    if (string.IsNullOrEmpty(x))
                    {
                        context.Response.Write("X is not provided");

                        return;
                    }

                    if (string.IsNullOrEmpty(y))
                    {
                        context.Response.Write("Y is not provided");

                        return;
                    }

                    if (!int.TryParse(x, out var intX))
                    {
                        context.Response.Write("X is not a number");

                        return;
                    }

                    if (!int.TryParse(y, out var intY))
                    {
                        context.Response.Write("Y is not a number");

                        return;
                    }

                    context.Response.Write(intX * intY);
                    break;
                }
            }
        }

        public bool IsReusable => true;
    }
}