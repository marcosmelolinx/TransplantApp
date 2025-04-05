using backend.Domain.Entities;
using backend.Domain.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using static backend.Application.Command.ExameCommand;

namespace backend.Application.Command;

public class ExameCommandHandler : IRequestHandler<CreateExameCommand, int>
{
    private readonly IExameRepository _exameRepository;

    public ExameCommandHandler(IExameRepository exameRepository)
    {
        _exameRepository = exameRepository;
    }
    public async Task<int> Handle(CreateExameCommand request, CancellationToken cancellationToken)
    {
        var exame = new Exame
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataExame = request.DataExame
        };

        await _exameRepository.AddExame(exame);
        return (int)exame.Id;
    }
}
