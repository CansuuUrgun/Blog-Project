using BlogProject.Domain.Entities;

namespace BlogProject.Application.Repositories;
public interface IPostRepository
{
    Task<Post> AddAsync(Post post);
    Task<Post?> GetByIdAsync(int id);
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post> UpdateAsync(Post post);
    Task DeleteAsync(int id);>
}
