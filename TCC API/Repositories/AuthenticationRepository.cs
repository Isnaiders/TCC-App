using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TCC_API.Interfaces.Repositories;
using TCC_API.Models.Entities;
using TCC_API.Models.Entities.Authentication;

namespace TCC_API.Repositories
{
	public class AuthenticationRepository : IAuthenticationRepository
	{
		private readonly TC_EstaVagaContext _context;

		public AuthenticationRepository(TC_EstaVagaContext context)
		{
			_context = context;
		}

		public void Add(Authentication authentication)
		{
			if (_context.Authentication.Any(e => e.UserName != authentication.UserName))
				_context.Authentication.Add(authentication);
		}

		public void Update(Authentication authentication)
		{
			_context.Authentication.Update(authentication);
		}

		public ValidationResult Remove(Guid userId)
		{
			var validationResult = new ValidationResult(string.Empty);
			var authenticationDB = _context.Authentication.Include(e => e.User).Where(e => e.UserId == userId).FirstOrDefault();

			if (authenticationDB != null)
			{
				_context.Authentication.Remove(authenticationDB);
				_context.User.Remove(authenticationDB.User);
			}
			else
			{
				validationResult.ErrorMessage = "Usuário não existe";
			}

			return validationResult;
		}

        public async Task<Authentication> GetById(Guid userId)
        {
            return await _context.Authentication.Include(e=> e.User).Where(e => e.UserId == userId).FirstOrDefaultAsync();
        }

		public async Task<bool> SaveAllAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public bool Login(string userName, string password)
		{
			return _context.Authentication.Any(e => e.UserName == userName && e.Password == password);
		}
	}
}
