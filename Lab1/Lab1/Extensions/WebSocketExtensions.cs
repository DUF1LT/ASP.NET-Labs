using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Lab1.Extensions
{
    public static class WebSocketExtensions
    {
        public static async Task<string> Receive(this WebSocket socket)
        {
            var buffer = new ArraySegment<byte>(new byte[512]);
            var result = await socket.ReceiveAsync(buffer, System.Threading.CancellationToken.None);
            return System.Text.Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
        }

        public static async Task Send(this WebSocket socket, string message)
        {
            var buffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(message));
            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);
        }
    }
}