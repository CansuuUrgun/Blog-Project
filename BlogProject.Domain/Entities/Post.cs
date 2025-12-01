using BlogProject.Domain.Exceptions;

namespace BlogProject.Domain.Entities;
public class Post
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public User Author { get; private set; } = null!;

    private Post(string title, string content, User author)
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
        Author = author ?? throw new DomainException("Author cannot be null");
        CreatedAt = DateTime.UtcNow;
    }

    public static Post Create(string title, string content, User author)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title cannot be empty");
        if (string.IsNullOrWhiteSpace(content))
            throw new DomainException("Content cannot be empty");
        if(author is null)
            throw new DomainException("Author cannot be null");
        var post =  new Post(title, content, author);
        
        author.AddPost(post);

        return post;
    }

    public void Update(string title, string content)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title cannot be empty"); 
        Title = title;
        if (string.IsNullOrWhiteSpace(content))
            throw new DomainException("Content cannot be empty");
        Content = content;
        UpdatedAt = DateTime.UtcNow;
    }
}
