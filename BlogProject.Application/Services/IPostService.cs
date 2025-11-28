using BlogProject.Application.Contracts;

namespace BlogProject.Application.Services;
public interface IPostService
{
    Task<PostResponse> CreateAsync(CreatePostRequest req);
    Task<IEnumerable<PostResponse>> GetAllAsync();
    Task<PostResponse?> GetByIdAsync(int id);
    Task UpdateAsync(int id, UpdatePostRequest req);
    Task DeleteAsync(int id);
}
