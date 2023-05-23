using System.ComponentModel.DataAnnotations;
using TCC_API.Models.Entities.Authentication;

namespace TCC_API.Interfaces.Repositories
{
	public interface IAuthenticationRepository
	{
		Task<Authentication> GetById(Guid userId);
		string Add(Authentication authentication);
		void Update(Authentication authentication);
		ValidationResult Remove(Guid userId);
		Task<bool> SaveAllAsync();
		bool Login(string userName, string password);
	}
}
