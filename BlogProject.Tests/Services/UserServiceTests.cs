using BlogProject.Application.Contracts;
using BlogProject.Application.Services;
using BlogProject.Application.Services.Concrete;
using BlogProject.Infrastructure.Repositories;

namespace BlogProject.Tests.Services;
public class UserServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldAddUser_ReturnResponse()
    {
        // Arrange
        var repo = new InMemoryUserRepository();
        var service = new UserService(repo);

        var req = new CreateUserRequest("testuser", "deneme@gmail.com", "Password123!");

        // Act
        var result = await service.CreateAsync(req);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(req.UserName, result.Username);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveUser()
    {
        // Arrange
        var repo = new InMemoryUserRepository();
        var service = new UserService(repo);
        var createReq = new CreateUserRequest("testuser", "test@gmail.com", "Password123!");
        var createdUser = await service.CreateAsync(createReq);

        //Act
        await repo.DeleteAsync(createdUser.Id);
        var deletedUser = await service.GetByIdAsync(createdUser.Id);

        // Assert
        Assert.Null(deletedUser);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUser()
    {
        // Arrange
        var repo = new InMemoryUserRepository();
        var service = new UserService(repo);
        var createReq = new CreateUserRequest("testuser", "test@gmail.com", "Password123!");
        var createdUser = await service.CreateAsync(createReq);

        // Act
        var result = await service.GetByIdAsync(createdUser.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(createdUser.Id, result?.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllPosts()
    {
        // Arrange
        var repo = new InMemoryUserRepository();
        var service = new UserService(repo);
        var createReq1 = new CreateUserRequest("testuser1", "test1@gmail.com", "Password123!");
        var createReq2 = new CreateUserRequest("testuser2", "test2@gmail.com", "Password123!");
        await service.CreateAsync(createReq1);
        await service.CreateAsync(createReq2);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
}
