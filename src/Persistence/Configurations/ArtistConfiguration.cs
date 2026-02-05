using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RymCloneApi.src.Domain;

namespace RymCloneApi.src.Persistence.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
  public void Configure(EntityTypeBuilder<Artist> builder)
  {
    builder.Property(s => s.Name).HasMaxLength(250).HasColumnType("varchar").IsRequired();
    builder.HasMany<Album>(e => e.Albums);
  }
}
