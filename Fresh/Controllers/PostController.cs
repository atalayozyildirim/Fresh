﻿using Bussnies.Abstract;
using Entity.Concrete;
using Fresh.Hubs;
using Fresh.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Fresh.Controllers;

[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly Context _Context;
    private readonly IHubContext<PostHub> _hubContext;

    public PostController(IPostService postService, IHubContext<PostHub> hubContext, Context context)
    {
        _postService = postService;
        _Context = context;
        _hubContext = hubContext;
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
            user_id = postModel.user_id,
            Author = postModel.Author,
            CreateDate = DateTime.Now,
            url = postModel.url,
            image = postModel.image
        };

        _postService.Add(posts);

        var hub = _hubContext.Clients.All;


        await _hubContext.Clients.All.SendAsync("SendPost", posts);

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

    [Route("/posts/get")]
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get()
    {
        var posts = _Context.Post.OrderByDescending(x => x.CreateDate).Take(10).ToList();
        return Ok(new { message = "OK", data = posts });
    }
   


    [Route("/posts/get/{id}")]
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get(string id)
    {
        var post = _postService.GetById(id);
        return Ok(new { message = "OK", data = post });
    }

    [Route("/posts/delete")]
    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok(new { message = "test" });
    }
}