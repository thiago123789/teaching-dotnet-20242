using Microsoft.EntityFrameworkCore;
using NGPD.Manager.Entities;

namespace NGPD.Manager.Data;

public class ManagerDbContext : DbContext
{
    public DbSet<Aluno> Alunos;
    public DbSet<Empresa> Empresas;
    public DbSet<Turma> Turmas;
    public DbSet<Mentor> Mentores;
    
    public ManagerDbContext(DbContextOptions options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        Audit();
        return base.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        Audit();
        return await base.SaveChangesAsync();
    }
    
    private void Audit()
    {
        var entries = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity &&
                        (x.State == EntityState.Added ||
                         x.State == EntityState.Modified ||
                         x.State == EntityState.Deleted));
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    ((BaseEntity)entry.Entity).CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    ((BaseEntity)entry.Entity).IsDeleted = true;
                    ((BaseEntity)entry.Entity).UpdateDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    ((BaseEntity)entry.Entity).UpdateDate = DateTime.UtcNow;
                    break;
            }
        }
    }
}