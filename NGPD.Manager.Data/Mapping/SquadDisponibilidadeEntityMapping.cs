using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGPD.Manager.Entities;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Data.Mapping;

public class SquadDisponibilidadeEntityMapping : IEntityTypeConfiguration<SquadDisponibilidade>
{
    public void Configure(EntityTypeBuilder<SquadDisponibilidade> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasOne<Squad>(e => e.Squad)
            .WithMany(e => e.SquadDisponibilidades);
        builder.HasOne<Disponibilidade>(e => e.Disponibilidade);
    }
}