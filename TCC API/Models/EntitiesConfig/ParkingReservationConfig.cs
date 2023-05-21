using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_API.Models.Entities;

namespace TCC_API.Models.EntitiesConfig
{
    public class ParkingReservationConfig : IEntityTypeConfiguration<ParkingReservation>
    {
        public void Configure(EntityTypeBuilder<ParkingReservation> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever().IsRequired().HasColumnName("ParkingReservationId");
            builder.HasOne(d => d.Car)
                    .WithMany(p => p.ParkingReservation)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ParkingReservation_dbo.Car_CarId");
            builder.HasOne(d => d.Parking)
                    .WithMany(p => p.ParkingReservation)
                    .HasForeignKey(d => d.ParkingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ParkingReservation_dbo.Parking_ParkingId");
            builder.HasOne(d => d.Vacancy)
                    .WithMany(p => p.ParkingReservation)
                    .HasForeignKey(d => d.VacancyId)
                    .HasConstraintName("FK_dbo.ParkingReservation_dbo.Vacancy_VacancyId");
        }
    }
}
