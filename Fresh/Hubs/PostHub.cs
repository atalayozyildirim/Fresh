using Bussnies.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

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
        if (post == null)
        {
            throw new ArgumentNullException(nameof(post), "Post cannot be null");
        }
        await Clients.All.SendCoreAsync("ReceivePost", new object?[] { post });
    }
    public async Task GetPosts(int start, int count)
    {
        var posts = _Context.Post.OrderByDescending(x => x.CreateDate).Skip(start).Take(count).ToList();
        if (!posts.Any())
        {
            await Clients.All.SendCoreAsync("ReceivePosts", new object?[] { new { message = "Post kalmadı " } });
        }
        await Clients.All.SendCoreAsync("ReceivePosts", new object?[] { posts });
    }
    public override async Task OnConnectedAsync()
    {
    }
    public async Task OnReceiveMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null or empty");
        }
        var data = JsonConvert.DeserializeObject<dynamic>(message);
        int start = data.start;
        int count = data.count;
        await GetPosts(start, count);
    }

}