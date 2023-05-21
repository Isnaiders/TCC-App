using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_API.Models.Entities.Parking;

namespace TCC_API.Models.EntitiesConfig.Parking
{
    public class ParkingReservationHistoryConfig : IEntityTypeConfiguration<ParkingReservationHistory>
    {
        public void Configure(EntityTypeBuilder<ParkingReservationHistory> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever().IsRequired().HasColumnName("ParkingReservationHistoryId");
            builder.HasOne(d => d.Car)
                    .WithMany(p => p.ParkingReservationHistory)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ParkingReservationHistory_dbo.Car_CarId");
            builder.HasOne(d => d.Parking)
                    .WithMany(p => p.ParkingReservationHistory)
                    .HasForeignKey(d => d.ParkingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ParkingReservationHistory_dbo.Parking_ParkingId");
            builder.HasOne(d => d.Vacancy)
                    .WithMany(p => p.ParkingReservationHistory)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ParkingReservationHistory_dbo.Vacancy_VacancyId");
        }
    }
}
