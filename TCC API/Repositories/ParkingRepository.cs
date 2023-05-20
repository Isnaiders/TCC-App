using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TCC_API.Interfaces;
using TCC_API.Models.Entities;

namespace TCC_API.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly TC_EstaVagaContext _context;

        public ParkingRepository(TC_EstaVagaContext context)
        {
            _context = context;
        }

        public void Add(Parking parking)
        {
            _context.Parking.Add(parking);
        }

        public void Update(Parking parking)
        {
            _context.Parking.Update(parking);
        }

        public ValidationResult Remove(Guid parkingId)
        {
            var validationResult = new ValidationResult(string.Empty);
            var parkingDB = _context.Parking.Find(parkingId);

            if (parkingDB != null)
            {
                _context.Parking.Remove(parkingDB);
            }
            else
            {
                validationResult.ErrorMessage = "Estacionamento não existe";
            }

            return validationResult;
        }

        public async Task<IEnumerable<Parking>> GetAll()
        {
            return await _context.Parking.ToListAsync();
        }

        public async Task<Parking> GetById(Guid parkingId)
        {
            return await _context.Parking.Where(e => e.Id == parkingId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
