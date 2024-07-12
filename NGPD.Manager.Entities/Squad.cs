using NGPD.Manager.Entities.Base;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Entities;

public class Squad : BaseEntity
{
    public virtual Turma Turma { get; set; }
    public virtual Mentor Mentor { get; set; }
    public virtual Empresa Empresa { get; set; }
    public virtual IList<SquadDisponibilidade> SquadDisponibilidades { get; set; }
}