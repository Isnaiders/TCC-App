using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC_API.Models.EntitiesConfig.Authentication
{
	public class AuthenticationConfig : IEntityTypeConfiguration<Entities.Authentication.Authentication>
	{
		public void Configure(EntityTypeBuilder<Entities.Authentication.Authentication> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedNever().IsRequired().HasColumnName("AuthenticationId");
			builder.HasOne(d => d.User)
					.WithMany(p => p.Authentication)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_dbo.Authentication_dbo.User_UserId");
		}
	}
}
