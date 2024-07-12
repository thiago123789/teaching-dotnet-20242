namespace NGPD.Manager.Entities.DTO;

public class DisponibilidadeInputDto
{
    public int DiaDaSemana { get; set; }
    public TimeSpan inicio { get; set; }
    public TimeSpan fim { get; set; }
}