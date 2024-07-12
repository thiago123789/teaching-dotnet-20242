using NGPD.Manager.Entities.Base;

namespace NGPD.Manager.Entities.Disponibilidade;

public class TurmaDisponibilidade : BaseEntity
{
    public virtual Turma Turma { get; set; }
    public virtual Disponibilidade Disponibilidade { get; set; }
}