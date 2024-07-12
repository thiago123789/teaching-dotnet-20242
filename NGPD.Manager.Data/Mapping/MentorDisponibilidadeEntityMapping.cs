using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGPD.Manager.Entities;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Data.Mapping;

public class MentorDisponibilidadeEntityMapping : IEntityTypeConfiguration<MentorDisponibilidade>
{
    public void Configure(EntityTypeBuilder<MentorDisponibilidade> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasOne<Mentor>(e => e.Mentor)
            .WithMany(e => e.MentorDisponibilidades);
        builder.HasOne<Disponibilidade>(e => e.Disponibilidade);
    }
}