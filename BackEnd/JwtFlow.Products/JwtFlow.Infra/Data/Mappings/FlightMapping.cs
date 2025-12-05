using JwtFlow.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        });

        builder.OwnsOne(x => x.FlightDate, date =>
        {
            date.Property(d => d.DateStart)
                .HasColumnName("DateStart")
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