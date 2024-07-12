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
    private IEmpresaRepository _empresaRepository;
    private IDisponibilidadeRepository _disponibilidadeRepository;
    private ISquadRepository _squadRepository;
    private IMentorRepository _mentorRepository;
    private IFaculdadeRepository _faculdadeRepository;

    #region Repo properties
    public IAlunoRepository AlunoRepository =>
        _alunoRepository ??= new AlunoRepository(_dbContext);
    public IEmpresaRepository EmpresaRepository => 
        _empresaRepository ??= new EmpresaRepository(_dbContext);
    public IDisponibilidadeRepository DisponibilidadeRepository =>
        _disponibilidadeRepository ??= new DisponibilidadeRepository(_dbContext);
    public IFaculdadeRepository FaculdadeRepository => 
        _faculdadeRepository ??= new FaculdadeRepository(_dbContext);
    public IMentorRepository MentorRepository => 
        _mentorRepository ??= new MentorRepository(_dbContext);
    public ISquadRepository SquadRepository => 
        _squadRepository ??= new SquadRepository(_dbContext);

    #endregion


    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public void ForceBeginTransaction()
    {
        _dbContext.Database.CurrentTransaction?.Dispose();
        _dbContext.Database.BeginTransaction();
    }

    public async Task CommitAsync()
    { 
        await _dbContext.Database.CommitTransactionAsync();
    }

    public void Commit()
    {
        _dbContext.Database.CommitTransaction();
    }

    public void RollbackTransaction()
    {
        _dbContext.Database.RollbackTransaction();
    }

    public async Task<int> SaveChangesAsync()
    {
        await CommitAsync();
        return await _dbContext.SaveChangesAsync();
    }

    public void SetIsolationLevel(IsolationLevel isolationLevel)
    {
        throw new NotImplementedException();
    }
}