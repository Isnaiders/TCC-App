using System.ComponentModel.DataAnnotations;
using TCC_API.Models.Entities.Parking;

namespace TCC_API.Interfaces.Repositories
{
    public interface IParkingRepository
    {
        Task<IEnumerable<Parking>> GetAll();
        Task<Parking> GetById(Guid parkingId);
        void Add(Parking parking);
        void Update(Parking parking);
        ValidationResult Remove(Guid parkingId);
        Task<bool> SaveAllAsync();
        bool Exists(Guid parkingId);
    }
}
