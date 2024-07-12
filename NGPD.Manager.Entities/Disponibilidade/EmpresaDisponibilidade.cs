using NGPD.Manager.Entities.Base;

namespace NGPD.Manager.Entities.Disponibilidade;

public class EmpresaDisponibilidade : BaseEntity
{
    public virtual Empresa Empresa { get; set; }
    public virtual Disponibilidade Disponibilidade { get; set; }
}