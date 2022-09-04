using System;
using System.Globalization;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;
using Lab1.Extensions;

namespace Lab1.Handlers
{
    public class WebSocketHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(HandleWebSocketRequest);

                return;
            }

            var fileName = AppDomain.CurrentDomain.BaseDirectory + "Views\\ws.html";
            context.Response.WriteFile(fileName);
        }

        private static async Task HandleWebSocketRequest(AspNetWebSocketContext context)
        {
            var socket = context.WebSocket;

            var initialMessage = await socket.Receive();
            await socket.Send(initialMessage);

            while (socket.State == WebSocketState.Open)
            {
                var currentTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);

                await Task.Delay(2000);
                await socket.Send(currentTime);
            }
        }

        public bool IsReusable => true;
    }
}