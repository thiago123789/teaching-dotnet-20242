using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Data.Mapping;

public class DisponibilidadeEntityMapping : IEntityTypeConfiguration<Disponibilidade>
{
    public void Configure(EntityTypeBuilder<Disponibilidade> builder)
    {
        builder.HasKey(e => e.Id);
        builder.OwnsOne(e => e.IntervaloTempo, ts =>
        {
            ts.Property(e => e.From).HasField("from").IsRequired();
            ts.Property(e => e.To).HasField("to").IsRequired();
            ts.OwnsOne(e=> e.DiaSemana).Property(e=>e.Id).IsRequired();
            ts.OwnsOne(e => e.DiaSemana).Property(e => e.Name).IsRequired();
        }).UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
    }
}