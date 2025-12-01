using BlogProject.Domain.Entities;

namespace BlogProject.Application.Contracts;
public record CreatePostRequest(string Title, string Content);