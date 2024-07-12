using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGPD.Manager.Entities;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Data.Mapping;

public class TurmaDisponibilidadeEntityMapping : IEntityTypeConfiguration<TurmaDisponibilidade>
{
    public void Configure(EntityTypeBuilder<TurmaDisponibilidade> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasOne<Turma>(e => e.Turma)
            .WithMany(e => e.TurmaDisponibilidades);
        builder.HasOne<Disponibilidade>(e => e.Disponibilidade);
    }
}