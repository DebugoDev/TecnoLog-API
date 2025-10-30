namespace Infrastructure.Data;

using Application.Entities;
using Microsoft.EntityFrameworkCore;

public sealed class TecnoLogDbContext(DbContextOptions<TecnoLogDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TecnoLogDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}