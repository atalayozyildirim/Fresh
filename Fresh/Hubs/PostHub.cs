using Bussnies.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Fresh.Hubs;

// [Authorize]
public class PostHub : Hub
{
    private readonly IPostService _postService;
    private readonly Context _Context;


    public PostHub(IPostService postService, Context context)
    {
        _postService = postService;
        _Context = context;
    }
    public async Task SendPost(Post post)
    {
        await Clients.All.SendCoreAsync("ReceivePost", new object?[] { post });
    }
    public async Task GetPosts()
    {
        Console.WriteLine("GetPosts method is called.");
        var posts = _Context.Post.OrderByDescending(x => x.CreateDate).Take(10).ToList();
        await Clients.All.SendCoreAsync("ReceivePosts", new object?[] { posts });
    }
    public override async Task OnConnectedAsync()
    {
        if (Context.ConnectionId != null)
        {
            await GetPosts();
        }
        await base.OnConnectedAsync();
    }
}