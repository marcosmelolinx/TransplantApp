// backend.Infrastructure.Data.ApplicationDbContext.cs
using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Exame> Exames { get; set; }

        // Construtor padrão para ser usado pelo EF Core
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public async Task CommitAsync()
        {   
            await SaveChangesAsync();
        }
    }
}