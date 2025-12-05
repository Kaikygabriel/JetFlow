using JwtFlow.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtFlow.Infra.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext>options) : DbContext(options)
{
    public DbSet<ProductFlight>Flights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FlightMapping());
    }
}