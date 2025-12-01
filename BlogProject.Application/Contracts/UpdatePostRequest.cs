using BlogProject.Domain.Entities;

namespace BlogProject.Application.Contracts;
public record UpdatePostRequest(string Title, string Content,User Author);
