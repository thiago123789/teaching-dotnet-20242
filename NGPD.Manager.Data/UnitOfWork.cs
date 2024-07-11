using System.Data;
using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Data.Contracts.Base;

namespace NGPD.Manager.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ManagerDbContext _dbContext;

    public UnitOfWork(ManagerDbContext dbContext)
    {
        this._dbContext = dbContext;
        ForceBeginTransaction();
    }

    private IAlunoRepository _alunoRepository;

    public IAlunoRepository AlunoRepository =>
        _alunoRepository ??= new AlunoRepository(_dbContext);
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void ForceBeginTransaction()
    {
        throw new NotImplementedException();
    }

    public Task CommitAsync()
    {
        throw new NotImplementedException();
    }

    public void Commit()
    {
        throw new NotImplementedException();
    }

    public void RollbackTransaction()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public void SetIsolationLevel(IsolationLevel isolationLevel)
    {
        throw new NotImplementedException();
    }
}