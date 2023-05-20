using System.ComponentModel.DataAnnotations;
using TCC_API.Models.Entities;

namespace TCC_API.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        ValidationResult Remove(Guid userId);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid userId);
        Task<bool> SaveAllAsync();
    }
}
