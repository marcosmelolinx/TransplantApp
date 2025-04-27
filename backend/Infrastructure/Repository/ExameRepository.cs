// backend.Infrastructure.Repository/ExameRepository.cs
using backend.Domain.Entities;
using backend.Domain.Interface;
using backend.Infrastructure.Data;

namespace backend.Infrastructure.Repository
{
    public class ExameRepository : IExameRepository
    {
        private readonly ApplicationDbContext _context;

        public ExameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddExame(Exame exame)
        {
            _context.Exames.Add(exame);
            await _context.SaveChangesAsync();
        }
    }
}
