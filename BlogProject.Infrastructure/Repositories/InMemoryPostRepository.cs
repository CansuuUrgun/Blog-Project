using BlogProject.Application.Repositories;
using BlogProject.Domain.Entities;

namespace BlogProject.Infrastructure.Repositories;
public class InMemoryPostRepository : IPostRepository
{
    private readonly List<Post> posts = new();
    private static int idCounter = 0;
    public async Task<Post> AddAsync(Post post)
    {
        var id = ++idCounter;
        post.SetId(id);
        posts.Add(post);
        return post;
    }
    
    public async Task DeleteAsync(int id)
    {
        var post = posts.FirstOrDefault(p => p.Id == id);
        if (post is not null) posts.Remove(post);
        return;
    }
    
    public async Task<Post?> UpdateAsync(Post post)
    {
        var postToUpdate = posts.FirstOrDefault(p => p.Id == post.Id);
        if (postToUpdate is not null)
            postToUpdate.Update(post.Title, post.Content);
        return postToUpdate;
    }
    public async Task<Post?> GetByIdAsync(int id) => posts.FirstOrDefault(p => p.Id == id);
    public async Task<IEnumerable<Post>> GetAllAsync() => posts;
}
