namespace NGPD.Manager.Entities.Disponibilidade;

public class EmpresaDisponibilidade : BaseEntity
{
    public virtual Empresa Empresa { get; set; }
    public virtual IList<Disponibilidade> Disponibilidades { get; set; }
}