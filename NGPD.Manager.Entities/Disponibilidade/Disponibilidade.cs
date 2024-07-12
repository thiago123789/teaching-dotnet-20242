using NGPD.Manager.Entities.Base;

namespace NGPD.Manager.Entities.Disponibilidade;

public class Disponibilidade : BaseEntity
{
    public IntervaloTempo IntervaloTempo { get; set; }
}