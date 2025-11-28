namespace BlogProject.Application.Contracts;
public record PostResponse(int Id, string Title, string Content, DateTime CreatedAt, DateTime? UpdatedAt);

