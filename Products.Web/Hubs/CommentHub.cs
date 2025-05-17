using Microsoft.AspNetCore.SignalR;
namespace Products.Web.Hubs
{
    public class CommentHub : Hub
    {
        public async Task SendComment(int productId, string username, string content)
        {
            await Clients.All.SendAsync("ReceiveComment", productId, username, content);
        }
    }
}
