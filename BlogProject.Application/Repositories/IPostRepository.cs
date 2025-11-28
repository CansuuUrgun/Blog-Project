using BlogProject.Domain.Entities;

namespace BlogProject.Application.Repositories;
public interface IPostRepository
{
    Task<Post> AddAsync(Post post);
    Task<Post?> GetByIdAsync(int id);
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post> UpdateAsync(int id, string title, string content);
    Task DeleteAsync(int id);
}
