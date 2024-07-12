using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGPD.Manager.Entities;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Data.Mapping;

public class TurmaEntityMapping : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany<Aluno>(e => e.Alunos);
        builder.HasMany<TurmaDisponibilidade>(e => e.TurmaDisponibilidades)
            .WithOne(e => e.Turma);
    }
}