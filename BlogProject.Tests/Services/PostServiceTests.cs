using BlogProject.Application.Contracts;
using BlogProject.Application.Services;
using BlogProject.Infrastructure.Repositories;

namespace BlogProject.Tests.Services;
public class PostServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldAddPost_ReturnResponse()
    {
        // Arrange
        var repo = new InMemoryPostRepository();
        var service = new PostService(repo);

        var req = new CreatePostRequest("Test Title", "Test content");
        
        // Act
        var result = await service.CreateAsync(req);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Title", result.Title);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdate_ReturnResponse()
    {
        // Arrange
        var repo = new InMemoryPostRepository();
        var service = new PostService(repo);
        var createReq = new CreatePostRequest("Create Title", "Create content");
        var createdPost = await service.CreateAsync(createReq);

        var updateReq = new UpdatePostRequest("Updated Title", "Updated content");
        
        // Act
        var result = await service.UpdateAsync(createdPost.Id,updateReq);
        
        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.UpdatedAt);

        Assert.Equal("Updated Title", result.Title);
        Assert.Equal(result.UpdatedAt.Value.Date, DateTime.Now.Date);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemovePost()
    {
        // Arrange
        var repo = new InMemoryPostRepository();
        var service = new PostService(repo);
        var createReq = new CreatePostRequest("Create Title", "Create content");
        var createdPost = await service.CreateAsync(createReq);
        
        // Act
        await service.DeleteAsync(createdPost.Id);
        var deletedPost = await repo.GetByIdAsync(createdPost.Id);
        
        // Assert
        Assert.Null(deletedPost);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllPosts()
    {
        // Arrange
        var repo = new InMemoryPostRepository();
        var service = new PostService(repo);
        var createReq1 = new CreatePostRequest("Title 1", "Content 1");
        var createReq2 = new CreatePostRequest("Title 2", "Content 2");
        await service.CreateAsync(createReq1);
        await service.CreateAsync(createReq2);
        
        // Act
        var result = await service.GetAllAsync();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPost()
    {
        // Arrange
        var repo = new InMemoryPostRepository();
        var service = new PostService(repo);
        var createReq = new CreatePostRequest("Title", "Content");
        var createdPost = await service.CreateAsync(createReq);
        
        // Act
        var result = await service.GetByIdAsync(createdPost.Id);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal("Title", result.Title);
    }
}
