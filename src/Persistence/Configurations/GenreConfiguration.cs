using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RymCloneApi.src.Domain;

namespace RymCloneApi.src.Persistence.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
  public void Configure(EntityTypeBuilder<Genre> builder)
  {
    builder.ToTable("genres");
    builder.Property(e => e.Id).HasColumnName("id");
    builder
      .Property(s => s.Name)
      .HasColumnName("name")
      .HasMaxLength(100)
      .HasColumnType("varchar")
      .IsRequired();
    builder.HasMany<Album>(e => e.Albums);
  }
}
