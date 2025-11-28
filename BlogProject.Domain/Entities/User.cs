using BlogProject.Domain.Exceptions;
using System.Globalization;

namespace BlogProject.Domain.Entities;
public class User
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<Post>? Posts { get; private set; }
    //private readonly List<Post> _posts = new();
    //public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();
    
    //TODO ROL??

    private User(string username, string email, string passwordHash)
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }
    public static User Create(string username, string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new DomainException("Username cannot be empty");
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email cannot be empty");
        if(!email.Contains('@'))
            throw new DomainException("Email is not valid");
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException("PasswordHash cannot be empty");
        return new User(username, email, passwordHash);
    }
    public void ChangeUsername(string newUserName)
    {
        if (string.IsNullOrWhiteSpace(newUserName))
            throw new DomainException("Username cannot be empty");
        Username = newUserName;
        UpdatedAt = DateTime.UtcNow;
    }
    public void ChangeEmail(string newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail))
            throw new DomainException("Email cannot be empty");
        if (!newEmail.Contains('@'))
            throw new DomainException("Email is not valid");
        Email = newEmail;
        UpdatedAt = DateTime.UtcNow;
    }
    public void ChangePasswordHash(string newPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(newPasswordHash))
            throw new DomainException("Password cannot be empty");
        PasswordHash = newPasswordHash;
        UpdatedAt = DateTime.UtcNow;
    }
    public void AddPost(Post post)
    {
        if (Posts == null)
            Posts = new List<Post>();
        Posts.Add(post);
        UpdatedAt = DateTime.UtcNow;
    }
    public void RemovePost(Post post)
    {
        if (Posts == null || !Posts.Contains(post))
            throw new DomainException("Post not found");
        Posts.Remove(post);
        UpdatedAt = DateTime.UtcNow;
    }
}
