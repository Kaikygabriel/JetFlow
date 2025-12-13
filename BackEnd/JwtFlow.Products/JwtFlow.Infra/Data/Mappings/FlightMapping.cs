using JwtFlow.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtFlow.Infra.Data.Mappings;

public class FlightMapping : IEntityTypeConfiguration<ProductFlight>
{
    public void Configure(EntityTypeBuilder<ProductFlight> builder)
    {
        builder.ToTable("Flights");
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.FlightCity, city =>
        {
            city.Property(c => c.CityStart)
                .HasColumnName("CityStart")
                .HasMaxLength(150)
                .HasColumnType("NVARCHAR")
                .IsRequired();
            
            city.Property(c => c.CityOut)
                .HasColumnName("CityOut")
                .HasMaxLength(150)
                .HasColumnType("NVARCHAR")
                .IsRequired();
        });

        builder.OwnsOne(x => x.FlightDate, date =>
        {
            date.Property(d => d.DateStart)
                .HasColumnName("DateStart")
                .IsRequired();
            date.Property(d => d.DateOut)
                .HasColumnName("DateOut")
                .IsRequired();
        });

        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .HasColumnType("NVARCHAR")
            .IsRequired();

        builder.Property(x => x.Price)
            .HasColumnType("MONEY")
            .IsRequired();
    }
}