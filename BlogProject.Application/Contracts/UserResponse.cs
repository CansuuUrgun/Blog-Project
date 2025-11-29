namespace BlogProject.Application.Contracts;
public record UserResponse(Guid Id, string Username, string Email, DateTime CreatedAt, DateTime? UpdatedAt);

