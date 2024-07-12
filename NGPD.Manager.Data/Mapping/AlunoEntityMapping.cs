using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGPD.Manager.Entities;

namespace NGPD.Manager.Data.Mapping;

public class AlunoEntityMapping : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(e => e.Nome).HasMaxLength(100);
        builder.HasIndex(a => new { a.Email }).IsUnique();
    }
}