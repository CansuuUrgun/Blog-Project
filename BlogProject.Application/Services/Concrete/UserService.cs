using BlogProject.Application.Contracts;
using BlogProject.Application.Repositories;
using BlogProject.Domain.Entities;

namespace BlogProject.Application.Services.Concrete;
public class UserService(IRepository<User> repository) : IUserService
{
    private readonly IRepository<User> userRepository = repository;

    public async Task<UserResponse> CreateAsync(CreateUserRequest req)
    {
        var user = User.Create(req.UserName, req.Email, BCrypt.Net.BCrypt.HashPassword(req.Password));
        await userRepository.AddAsync(user);

        return new UserResponse(user.Id, user.Username, user.Email, user.CreatedAt,user.UpdatedAt);
    }

    public async Task<IEnumerable<UserResponse>> GetAllAsync()
    {
        var users = await userRepository.GetAllAsync();
        return users.Select(user => new UserResponse(user.Id, user.Username, user.Email, user.CreatedAt,user.UpdatedAt));
    }
    public async Task<UserResponse?> UpdateAsync(Guid id, UpdateUserRequest req)
    {
        var user = User.Create(req.UserName, req.Email, BCrypt.Net.BCrypt.HashPassword(req.Password));
        var updatedUser = await userRepository.UpdateAsync(id, user);
        if(updatedUser == null) return null;

        return new UserResponse(updatedUser.Id, updatedUser.Username, updatedUser.Email, updatedUser.CreatedAt,updatedUser.UpdatedAt);
    }

    public async Task<UserResponse?> GetByIdAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id);
        if (user == null) return null;
        return new UserResponse(user.Id, user.Username, user.Email, user.CreatedAt,user.UpdatedAt);
    }
    public async Task DeleteAsync(Guid id) => await userRepository.DeleteAsync(id);

    public Task<IEnumerable<PostResponse>> GetPostsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
    public Task<PostResponse> AddPostAsync(Guid userId, CreatePostRequest req)
    {
        throw new NotImplementedException();
    }

    
}
