using System.ComponentModel.DataAnnotations;
using TCC_API.Models.Entities.User;

namespace TCC_API.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid userId);
        void Add(User user);
        void Update(User user);
        ValidationResult Remove(Guid userId);
        Task<bool> SaveAllAsync();
        bool Exists(Guid Id);
    }
}
