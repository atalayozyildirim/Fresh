using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Fresh.Hubs;

// [Authorize]
public class PostHub : Hub
{
    public async Task SendPost(Post post)
    {
        await Clients.All.SendCoreAsync("ReceivePost", new object?[] { post });
    }
    
}