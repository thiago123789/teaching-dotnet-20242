using NGPD.Manager.Entities.Base;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Entities;

public class Turma : BaseEntity
{
    public virtual IList<Aluno> Alunos { get; set; }
    public virtual IList<TurmaDisponibilidade> TurmaDisponibilidades { get; set; }
}