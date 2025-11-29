namespace BlogProject.Application.Contracts;
public record PostResponse(Guid Id, string Title, string Content, DateTime CreatedAt, DateTime? UpdatedAt);

