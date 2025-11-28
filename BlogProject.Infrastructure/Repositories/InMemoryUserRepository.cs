using BlogProject.Application.Repositories;
using BlogProject.Domain.Entities;

namespace BlogProject.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IRepository<User>
    {
        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateAsync(Guid id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
