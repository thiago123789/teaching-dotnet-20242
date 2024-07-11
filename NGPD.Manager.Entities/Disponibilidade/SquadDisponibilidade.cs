namespace NGPD.Manager.Entities.Disponibilidade;

public class SquadDisponibilidade : BaseEntity
{
    public virtual Squad Squad { get; set; }
    public virtual IList<Disponibilidade> Disponibilidades { get; set; }
}