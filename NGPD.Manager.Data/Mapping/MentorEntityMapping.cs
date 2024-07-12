using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGPD.Manager.Entities;
using NGPD.Manager.Entities.Disponibilidade;

namespace NGPD.Manager.Data.Mapping;

public class MentorEntityMapping : IEntityTypeConfiguration<Mentor>
{
    public void Configure(EntityTypeBuilder<Mentor> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany<MentorDisponibilidade>(e => e.MentorDisponibilidades)
            .WithOne(e => e.Mentor);
    }
}