using NGPD.Manager.Entities.Base;

namespace NGPD.Manager.Entities.Disponibilidade;

public class MentorDisponibilidade : BaseEntity
{
    public virtual Mentor Mentor { get; set; }
    public virtual Disponibilidade Disponibilidade { get; set; }
}