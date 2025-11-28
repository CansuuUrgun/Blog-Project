using BlogProject.Application.Repositories;
using BlogProject.Domain.Entities;
using System.Data;

namespace BlogProject.Infrastructure.Repositories;
public class InMemoryPostRepository : IRepository<Post>
{
    private static readonly List<Post> posts = new();
    public async Task<Post> AddAsync(Post post)
    {
        //var id = ++idCounter;
        //post.SetId(id);
        posts.Add(post);
        return post;
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var post = posts.FirstOrDefault(p => p.Id == id);
        if (post is not null) posts.Remove(post);
        return;
    }
    
    public async Task<Post?> UpdateAsync(Guid id, Post post)
    {
        var postToUpdate = posts.FirstOrDefault(p => p.Id == id);
        //if (postToUpdate is not null)
        //    postToUpdate.Update(title, content);
        return postToUpdate;
    }
    public async Task<Post?> GetByIdAsync(Guid id) => posts.FirstOrDefault(p => p.Id == id);
    public async Task<IEnumerable<Post>> GetAllAsync() => posts;
}
