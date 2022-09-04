﻿using System.Web;

namespace Lab1.Handlers
{
    public class Task4 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
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

            context.Response.Write(intX + intY);
        }

        public bool IsReusable => true;
    }
}