using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Entities;

namespace NGPD.Manager.Data;

public class FaculdadeRepository : Repository<Faculdade>, IFaculdadeRepository
{
    public FaculdadeRepository(ManagerDbContext dbContext) : base(dbContext)
    {
    }
}