using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JetFlow.Infra.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
            .HasConversion(x => x.Address, b => new Email(b))
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR")
            .IsRequired(true);

        builder.Property(x => x.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired(true);
        
        builder.Property(x => x.Password)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(140)
            .IsRequired(true);
        
    }
}