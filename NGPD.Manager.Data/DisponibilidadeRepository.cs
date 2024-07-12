using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Data;

public class DisponibilidadeRepository : Repository<Disponibilidade>, IDisponibilidadeRepository
{
    public DisponibilidadeRepository(ManagerDbContext dbContext) : base(dbContext)
    {
    }
}