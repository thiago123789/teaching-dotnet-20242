using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Entities;

namespace NGPD.Manager.Data;

public class AlunoRepository : Repository<Aluno>, IAlunoRepository 
{
    public AlunoRepository(ManagerDbContext dbContext) : base(dbContext)
    {
    }
}