using BlogProject.Application.Contracts;
using BlogProject.Application.Repositories;
using BlogProject.Domain.Entities;

namespace BlogProject.Application.Services;
public class PostService(IPostRepository postRepository) : IPostService
{
    private readonly IPostRepository postRepository = postRepository;

    public async Task<PostResponse> CreateAsync(CreatePostRequest req)
    {
        var post = new Post(req.Title, req.Content);
        await postRepository.AddAsync(post);

        return new PostResponse(post.Id, post.Title, post.Content, post.CreatedAt, post.UpdatedAt);
    }

    public async Task DeleteAsync(int id)
    {
        await postRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PostResponse>> GetAllAsync()
    {
        var posts = await postRepository.GetAllAsync();
        return posts.Select(p => new PostResponse(p.Id, p.Title, p.Content, p.CreatedAt, p.UpdatedAt));
    }

    public async Task<PostResponse?> GetByIdAsync(int id)
    {
        var post = await postRepository.GetByIdAsync(id);
        if (post is null) return null;
        return new PostResponse(post.Id, post.Title, post.Content, post.CreatedAt, post.UpdatedAt);
    }

    public async Task<PostResponse?> UpdateAsync(int id, UpdatePostRequest req)
    {
        var updated = await postRepository.UpdateAsync(id, req.Title, req.Content);
        if (updated is null) return null;
        
        return new PostResponse(updated.Id, updated.Title, updated.Content, updated.CreatedAt, updated.UpdatedAt);
    }
}
