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

    public async Task<IEnumerable<PostResponse>?> GetPostsAsync(Guid userId)
    {
        var user = await userRepository.GetByIdAsync(userId);
        if (user == null) return null;
        return user.Posts?.Select(p =>  new PostResponse(p.Id, p.Title, p.Content, p.CreatedAt, p.UpdatedAt, p.Author.Username));
    }
    public async Task<PostResponse> AddPostAsync(Guid userId, CreatePostRequest req)
    {
        User? user = await userRepository.GetByIdAsync(userId);
        if (user == null) throw new Exception("User not found");

        var post = Post.Create(req.Title, req.Content, user);

        return new PostResponse
        (
            post.Id,
            post.Title,
            post.Content,
            post.CreatedAt,
            post.UpdatedAt,
            post.Author.Username
        );
    }

    public async Task DeletePostFromUser(Guid userId, Guid postId)
    {
        var user = await userRepository.GetByIdAsync(userId);
        if (user == null) throw new Exception("User not found");
        
        var post = user?.Posts.FirstOrDefault(p => p.Id == postId);
        if (post == null) throw new Exception("Post not found");
        
        user?.RemovePost(post);
    }
}
