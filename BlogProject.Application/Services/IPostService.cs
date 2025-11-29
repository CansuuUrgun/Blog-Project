using BlogProject.Application.Contracts;

namespace BlogProject.Application.Services;
public interface IPostService
{
    Task<PostResponse> CreateAsync(CreatePostRequest req);
    Task<IEnumerable<PostResponse>> GetAllAsync();
    Task<PostResponse?> GetByIdAsync(Guid id);
    Task<PostResponse?> UpdateAsync(Guid id, UpdatePostRequest req);
    Task DeleteAsync(Guid id);
}
