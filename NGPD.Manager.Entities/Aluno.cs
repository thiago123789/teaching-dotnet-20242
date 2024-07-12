using NGPD.Manager.Entities.Base;

namespace NGPD.Manager.Entities;

public class Aluno : BaseEntity
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public virtual Turma Turma { get; set; }
}