using Bussiness.Concrete;
using Bussnies.Abstract;
using Entity.Concrete;
using Fresh.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fresh.Controllers;

[ApiController]
public class PostController: ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    [Route("/posts")]
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(new { message = "test" });
    }
    
    [Route("/posts/add")]
    [HttpPost]
    public async Task<IActionResult> Add(Post model)
    {
        var add = _postService.Add(model);
        return Ok(new { message = "Post added" , data = add });
    }
}