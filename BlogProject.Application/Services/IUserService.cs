using BlogProject.Application.Contracts;

namespace BlogProject.Application.Services;
public interface IUserService
{
    Task<UserResponse> CreateAsync(CreateUserRequest req);
    Task<UserResponse?> UpdateAsync(Guid id, UpdateUserRequest req);
    Task<UserResponse?> GetByIdAsync(Guid id);
    Task<IEnumerable<UserResponse>> GetAllAsync();
    Task DeleteAsync(Guid id);
    Task<PostResponse> AddPostAsync(Guid userId, CreatePostRequest req);
    Task<IEnumerable<PostResponse>?> GetPostsAsync(Guid userId);
}
