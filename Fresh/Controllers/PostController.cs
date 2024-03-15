using Bussnies.Abstract;
using Entity.Concrete;
using Fresh.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fresh.Controllers;

[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    [Route("/posts")]
    [HttpGet]
    [Authorize]
    public IActionResult Index()
    {
        return Ok(new { message = "test" });
    }

    [Route("/posts/add")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] PostModel postModel)
    {

        if (postModel == null) return BadRequest(new { message = "Model is null" });
        var posts = new Post
        {
            Title = postModel.Title,
            Content = postModel.Content,
            user_id = postModel.user_id
        };
        _postService.Add(posts);

        return Ok(new { message = "Post added", model = postModel });
    }
    [Route("/posts/update")]
    [HttpPut]
    public IActionResult Update([FromBody] Post post)
    {
        if (post == null) return BadRequest(new { message = "Model is null" });
        _postService.Update(post);
        return Ok(new { message = "Post updated", model = post });
    }

    [Route("/posts/delete")]
    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok(new { message = "test" });
    }
}