using Bussnies.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Fresh.Controllers;

[ApiController]
public class CommentController : ControllerBase
{
    private ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    [Route("/comment")]
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("CommentController");
    }

    [Route("/comment/add")]
    [HttpPost]
    public IActionResult Add([FromBody] Comment comment)
    {
        if (comment == null) return BadRequest("Comment is null");
         _commentService.Add(comment);
       
        return Ok(new {message = "comment added",data = comment});
    }
    [Route("/comment/update")]
    [HttpPut]
    public IActionResult Update([FromBody] Comment comment)
    {
        if (comment == null) return BadRequest("Comment is null");
        _commentService.Update(comment);
        return Ok(new {message = "comment updated",data = comment});
    }
    
    [Route("/comment/delete")]
    [HttpDelete]
    public IActionResult Delete([FromBody] Comment comment)
    {
        if (comment == null) return BadRequest("Comment is null");
        _commentService.Delete(comment);
        return Ok(new {message = "comment deleted",data = comment});
    }
  
}