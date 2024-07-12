using NGPD.Manager.Entities.Base;

namespace NGPD.Manager.Entities;

public class Faculdade : BaseEntity
{
    public string Nome { get; set; }
    public virtual IList<Turma> Turmas { get; set; }
}