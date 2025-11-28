using BlogProject.Application.Contracts;
using BlogProject.Application.Repositories;
using BlogProject.Domain.Entities;

namespace BlogProject.Application.Services.Concrete;
public class UserService(IUserRepository repository) : IUserService
{
    private readonly IUserRepository repository = repository;

    public Task<UserResponse> CreateAsync(CreateUserRequest req)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(req.Password);
        var user = User.Create(req.UserName, req.Email, passwordHash);


    }

    public Task<IEnumerable<UserResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PostResponse>> GetPostsAsync(int userId)
    {
        throw new NotImplementedException();
    }
    public Task<PostResponse> AddPostAsync(int userId, CreatePostRequest req)
    {
        throw new NotImplementedException();
    }
}
