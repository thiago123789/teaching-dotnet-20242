using Microsoft.EntityFrameworkCore;
using NGPD.Manager.Data.Mapping;
using NGPD.Manager.Entities;
using NGPD.Manager.Entities.Base;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Data;

public class ManagerDbContext : DbContext
{
    public DbSet<Aluno> Alunos;
    public DbSet<Empresa> Empresas;
    public DbSet<Turma> Turmas;
    public DbSet<Mentor> Mentores;
    public DbSet<Squad> Squads;
    public DbSet<Disponibilidade> Disponibilidades { get; set; }

    public ManagerDbContext(DbContextOptions<ManagerDbContext> contextOptions) : base(contextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AlunoEntityMapping());
        modelBuilder.ApplyConfiguration(new DisponibilidadeEntityMapping());
        modelBuilder.ApplyConfiguration(new EmpresaEntityMapping());
        modelBuilder.ApplyConfiguration(new MentorDisponibilidadeEntityMapping());
        modelBuilder.ApplyConfiguration(new MentorEntityMapping());
        modelBuilder.ApplyConfiguration(new SquadDisponibilidadeEntityMapping());
        modelBuilder.ApplyConfiguration(new SquadEntityMapping());
        modelBuilder.ApplyConfiguration(new TurmaDisponibilidadeEntityMapping());
        modelBuilder.ApplyConfiguration(new TurmaEntityMapping());

        modelBuilder.Entity<Faculdade>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Faculdade>()
            .HasMany<Turma>(e => e.Turmas);
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
                    ((BaseEntity)entry.Entity).LastModifiedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    ((BaseEntity)entry.Entity).LastModifiedDate = DateTime.UtcNow;
                    break;
            }
        }
    }
}