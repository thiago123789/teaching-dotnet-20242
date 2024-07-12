using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGPD.Manager.Entities;

namespace NGPD.Manager.Data.Mapping;

public class SquadEntityMapping : IEntityTypeConfiguration<Squad>
{
    public void Configure(EntityTypeBuilder<Squad> builder)
    {
        builder.HasKey(e => e.Id);
    }
}