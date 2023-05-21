using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_API.Models.Entities;

namespace TCC_API.Models.EntitiesConfig
{
    public class ParkingOpeningHourConfig : IEntityTypeConfiguration<ParkingOpeningHour>
    {
        public void Configure(EntityTypeBuilder<ParkingOpeningHour> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever().IsRequired().HasColumnName("ParkingOpeningHourId");
            builder.HasOne(d => d.Parking)
                    .WithMany(p => p.ParkingOpeningHour)
                    .HasForeignKey(d => d.ParkingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ParkingOpeningHour_dbo.Parking_ParkingId");
        }
    }
}
