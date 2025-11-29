using BlogProject.Application.Contracts;
using BlogProject.Application.Repositories;
using BlogProject.Domain.Entities;

namespace BlogProject.Application.Services;
public class PostService(IRepository<Post> postRepository) : IPostService
{
    private readonly IRepository<Post> postRepository = postRepository;

    public async Task<PostResponse> CreateAsync(CreatePostRequest req)
    {
        var post = Post.Create(req.Title, req.Content,null);
        await postRepository.AddAsync(post);

        return new PostResponse(post.Id, post.Title, post.Content, post.CreatedAt, post.UpdatedAt);
    }

    public async Task DeleteAsync(Guid id) => await postRepository.DeleteAsync(id);

    public async Task<IEnumerable<PostResponse>> GetAllAsync()
    {
        var posts = await postRepository.GetAllAsync();
        return posts.Select(p => new PostResponse(p.Id, p.Title, p.Content, p.CreatedAt, p.UpdatedAt));
    }

    public async Task<PostResponse?> GetByIdAsync(Guid id)
    {
        var post = await postRepository.GetByIdAsync(id);
        if (post is null) return null;
        return new PostResponse(post.Id, post.Title, post.Content, post.CreatedAt, post.UpdatedAt);
    }

    public async Task<PostResponse?> UpdateAsync(Guid id, UpdatePostRequest req)
    {
        var post = Post.Create(req.Title, req.Content, null);
        var updated = await postRepository.UpdateAsync(id, post);
        if (updated is null) return null;

        return new PostResponse(updated.Id, updated.Title, updated.Content, updated.CreatedAt, updated.UpdatedAt);
    }
}
