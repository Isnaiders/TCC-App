using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Entities.Parking;
using TCC_API.Models.Entities.User;
using TCC_API.Models.EntitiesConfig.Authentication;
using TCC_API.Models.EntitiesConfig.Parking;
using TCC_API.Models.EntitiesConfig.User;

namespace TCC_API.Models.Entities
{
	public partial class TC_EstaVagaContext : DbContext
	{
		public TC_EstaVagaContext()
		{
		}

		public TC_EstaVagaContext(DbContextOptions<TC_EstaVagaContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Authentication.Authentication> Authentication { get; set; }
		public virtual DbSet<Car> Car { get; set; }
		public virtual DbSet<Parking.Parking> Parking { get; set; }
		public virtual DbSet<ParkingOpeningHour> ParkingOpeningHour { get; set; }
		public virtual DbSet<ParkingReservation> ParkingReservation { get; set; }
		public virtual DbSet<ParkingReservationHistory> ParkingReservationHistory { get; set; }
		public virtual DbSet<User.User> User { get; set; }
		public virtual DbSet<Vacancy> Vacancy { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AuthenticationConfig());

			modelBuilder.ApplyConfiguration(new CarConfig());

			modelBuilder.ApplyConfiguration(new ParkingConfig());

			modelBuilder.ApplyConfiguration(new ParkingOpeningHourConfig());

			modelBuilder.ApplyConfiguration(new ParkingReservationConfig());

			modelBuilder.ApplyConfiguration(new ParkingReservationHistoryConfig());

			modelBuilder.ApplyConfiguration(new UserConfig());

			modelBuilder.ApplyConfiguration(new VacancyConfig());

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}