using BlogProject.Application.Contracts;
using BlogProject.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController(IPostService postService) : ControllerBase
{
    private readonly IPostService postService = postService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await postService.GetAllAsync();
        return Ok(posts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var post = await postService.GetByIdAsync(id);
        if (post is null) return NotFound();
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostRequest req)
    {
        var createdPost = await postService.CreateAsync(req);
        return CreatedAtAction(nameof(GetById), new { id = createdPost.Id }, createdPost);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePostRequest req)
    {
        var updated = await postService.UpdateAsync(id, req);
        
        if (updated is null)
            return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await postService.DeleteAsync(id);
        return NoContent();
    }
}
