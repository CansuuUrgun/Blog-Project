using BlogProject.Application.Repositories;
using BlogProject.Domain.Entities;

namespace BlogProject.Infrastructure.Repositories;
public class InMemoryUserRepository : IRepository<User>
{
    private static readonly List<User> users = new();
    public async Task<User> AddAsync(User entity)
    {
        users.Add(entity);
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user is not null) users.Remove(user);
        return;
    }
    
    public async Task<User?> UpdateAsync(Guid id, User entity)
    {
        var userToUpdate = users.FirstOrDefault(u => u.Id == id);
        if (userToUpdate is not null)
            userToUpdate.Update(entity.Username, entity.Email, entity.PasswordHash);
        
        return userToUpdate;
    }
    public async Task<IEnumerable<User>> GetAllAsync() => users;
    public async Task<User?> GetByIdAsync(Guid id) => users.FirstOrDefault(u => u.Id == id);
}
