using BlogProject.Application.Contracts;

namespace BlogProject.Application.Services;
public interface IUserService
{
    Task<UserResponse> CreateAsync(CreateUserRequest req);
    //Task<UserResponse?> UpdateAsync(int id, UpdateUserRequest req);
    Task<UserResponse?> GetByIdAsync(int id);
    Task<IEnumerable<UserResponse>> GetAllAsync();
    Task<PostResponse> AddPostAsync(int userId, CreatePostRequest req);
    Task<IEnumerable<PostResponse>> GetPostsAsync(int userId);
}
