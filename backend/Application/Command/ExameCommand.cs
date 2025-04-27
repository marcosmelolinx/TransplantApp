using MediatR;

namespace backend.Application.Command

{
    public class ExameCommand
    {
        public class CreateExameCommand : IRequest<int>
        {
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public DateTime DataExame { get; set; }
        }
    }
}
