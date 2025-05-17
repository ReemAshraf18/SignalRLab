using Microsoft.AspNetCore.SignalR;

namespace Products.Hubs
{
    public class CommentHub : Hub
    {
        public async Task SendComment(string userName, string content, int productId)
        {
            await Clients.All.SendAsync("ReceiveComment", userName, content, productId);
        }
    }
}
