namespace BlogProject.Application.Contracts;
public record UserResponse(int Id, string Username, string Email, DateTime CreatedAt, DateTime? UpdatedAt);

