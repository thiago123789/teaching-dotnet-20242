using NGPD.Manager.Entities.Base;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Entities;

public class Mentor : BaseEntity
{
    public string Nome { get; set; }

    public virtual IList<Squad> Squads { get; set; }
    public virtual IList<MentorDisponibilidade> MentorDisponibilidades { get; set; }
}