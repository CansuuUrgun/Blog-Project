namespace BlogProject.Domain.Entities;
public class Post
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Post(string title, string content)
    {
        Title = title;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    public void SetId(int id) => Id = id;
    public void Update(string title, string content)
    {
        Title = title;
        Content = content;
        UpdatedAt = DateTime.UtcNow;
    }
}
