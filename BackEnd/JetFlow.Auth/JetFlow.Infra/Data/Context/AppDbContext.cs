using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace JetFlow.Infra.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext>options) : DbContext(options)
{
    public DbSet<User>Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMapping());
    }
}