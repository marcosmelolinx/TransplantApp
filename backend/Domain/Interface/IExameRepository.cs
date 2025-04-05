using backend.Domain.Entities;

namespace backend.Domain.Interface;

public interface IExameRepository
{
    Task AddExame(Exame exame);
}
