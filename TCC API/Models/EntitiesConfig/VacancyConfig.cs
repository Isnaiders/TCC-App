using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_API.Models.Entities;

namespace TCC_API.Models.EntitiesConfig
{
    public class VacancyConfig : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever().IsRequired().HasColumnName("VacancyId");
            builder.HasOne(d => d.Parking)
                    .WithMany(p => p.Vacancy)
                    .HasForeignKey(d => d.ParkingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Vacancy_dbo.Parking_ParkingId");
        }
    }
}
