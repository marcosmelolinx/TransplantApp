namespace backend.Domain.Entities;

public class Exame
{
    public int? Id{ get; set; }
    public int? Tipo{ get; set; }
    public string? Nome{ get; set; }
    public string? Profissional { get; set; }
    public string? Paciente { get; set; }
    public DateTime DataExame { get; set; }
    public string? Descricao { get; set; }
}
