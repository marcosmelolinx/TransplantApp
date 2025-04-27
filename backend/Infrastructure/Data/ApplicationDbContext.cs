// backend.Infrastructure.Data.ApplicationDbContext.cs
using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Exame> Exames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Sqlite.db");
    

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}