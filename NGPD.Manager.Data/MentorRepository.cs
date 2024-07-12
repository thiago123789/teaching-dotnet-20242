using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Entities;

namespace NGPD.Manager.Data;

public class MentorRepository : Repository<Mentor>, IMentorRepository
{
    public MentorRepository(ManagerDbContext dbContext) : base(dbContext)
    {
    }
}