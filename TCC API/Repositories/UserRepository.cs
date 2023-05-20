using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TCC_API.Interfaces;
using TCC_API.Models.Entities;

namespace TCC_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TC_EstaVagaContext _context;

        public UserRepository(TC_EstaVagaContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.User.Add(user);
        }

        public void Update(User user)
        {
            _context.User.Update(user);
        }

        public ValidationResult Remove(Guid userId)
        {
            var validationResult = new ValidationResult(string.Empty);
            var userDB = _context.User.Find(userId);

            if (userDB != null)
            {
                _context.User.Remove(userDB);
            }
            else
            {
                validationResult.ErrorMessage = "Usuário não existe";
            }

            return validationResult;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetById(Guid userId)
        {
            return await _context.User.Where(e => e.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Exists(Guid userId)
        {
            return _context.User.Find(userId) != null;
        }
    }
}
