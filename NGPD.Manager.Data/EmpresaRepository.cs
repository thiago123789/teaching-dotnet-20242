using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Entities;

namespace NGPD.Manager.Data;

public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
{
    public EmpresaRepository(ManagerDbContext dbContext) : base(dbContext)
    {
    }
}