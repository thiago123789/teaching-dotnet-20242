using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Entities;

namespace NGPD.Manager.Data;

public class SquadRepository : Repository<Squad>, ISquadRepository
{
    public SquadRepository(ManagerDbContext dbContext) : base(dbContext)
    {
    }
}