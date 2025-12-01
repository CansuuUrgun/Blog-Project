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
    private readonly List<Post> posts = new();
    public IReadOnlyCollection<Post> Posts => posts.AsReadOnly();

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
    public void Update(string userName,string email, string passwordHash, List<Post> posts)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new DomainException("Username cannot be empty");
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email cannot be empty");
        if (!email.Contains('@'))
            throw new DomainException("Email not valid");
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException("Password cannot be empty");
        Username = userName;
        Email = email;
        PasswordHash = passwordHash;
        UpdatedAt = DateTime.UtcNow;
        posts = posts; //TODO Kalkabilir?
    }
    public void AddPost(Post post)
    {
        posts.Add(post);
        UpdatedAt = DateTime.UtcNow;
    }
    public void RemovePost(Post post)
    {
        if (Posts == null || !Posts.Contains(post))
            throw new DomainException("Post not found");
        posts.Remove(post);
        UpdatedAt = DateTime.UtcNow;
    }
}
