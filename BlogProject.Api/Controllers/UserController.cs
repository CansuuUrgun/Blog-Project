using BlogProject.Application.Contracts;
using BlogProject.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await userService.GetByIdAsync(id);
        if (user is null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest req)
    {
        var createdUser = await userService.CreateAsync(req);
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserRequest req)
    {
        var updated = await userService.UpdateAsync(id, req);
        
        if (updated is null)
            return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await userService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPost("{userId:Guid}/posts")]
    public async Task<IActionResult> AddPost(Guid userId, [FromBody] CreatePostRequest req)
    {
        var post = await userService.AddPostAsync(userId, req);
        return Ok(post);
    }

    [HttpGet("{userId:Guid}/posts")]
    public async Task<IActionResult> GetPosts(Guid userId)
    {
        var posts = await userService.GetPostsAsync(userId);
        if (posts is null) return NotFound();
        return Ok(posts);
    }
}
