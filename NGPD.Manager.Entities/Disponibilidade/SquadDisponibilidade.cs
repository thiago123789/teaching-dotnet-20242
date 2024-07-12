using NGPD.Manager.Entities.Base;

namespace NGPD.Manager.Entities.Disponibilidade;

public class SquadDisponibilidade : BaseEntity
{
    public virtual Squad Squad { get; set; }
    public virtual Disponibilidade Disponibilidade { get; set; }
}