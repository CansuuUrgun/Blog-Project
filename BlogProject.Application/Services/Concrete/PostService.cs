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

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PostResponse?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, UpdatePostRequest req)
    {
        throw new NotImplementedException();
    }
}
