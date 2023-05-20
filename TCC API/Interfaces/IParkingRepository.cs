using System.ComponentModel.DataAnnotations;
using TCC_API.Models.Entities;

namespace TCC_API.Interfaces
{
    public interface IParkingRepository
    {
        void Add(Parking parking);
        void Update(Parking parking);
        ValidationResult Remove(Guid parkingId);
        Task<IEnumerable<Parking>> GetAll();
        Task<Parking> GetById(Guid parkingId);
        Task<bool> SaveAllAsync();
    }
}
