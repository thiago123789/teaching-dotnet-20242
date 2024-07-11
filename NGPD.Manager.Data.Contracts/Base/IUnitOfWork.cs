using System.Data;

namespace NGPD.Manager.Data.Contracts.Base;

public interface IUnitOfWork : IDisposable
{
    public IAlunoRepository AlunoRepository { get; }

    /// <summary>
    /// Opens a new transaction instantly when being called.
    /// If a transaction is already open, it won't do anything.
    /// Generally, you shouldn't call this method unless you need
    /// to control the exact moment of opening a transaction.
    /// Unit of Work automatically handles opening transactions
    /// in a convenient time.        
    /// </summary>
    void ForceBeginTransaction();

    /// <summary>
    /// Commits the current transaction (does nothing when none exists).
    /// </summary>
    Task CommitAsync();

    /// <summary>
    /// Commits the current transaction
    /// </summary>
    void Commit();

    /// <summary>
    /// Rolls back the current transaction (does nothing when none exists).
    /// </summary>
    void RollbackTransaction();

    /// <summary>
    /// Saves changes to database, previously opening a transaction
    /// only when none exists. The transaction is opened with isolation
    /// level set in Unit of Work before calling this method.
    /// </summary>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Sets the isolation level for new transactions.
    /// </summary>
    /// <param name="isolationLevel"></param>
    void SetIsolationLevel(IsolationLevel isolationLevel);
}