using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RymCloneApi.src.Domain;

namespace RymCloneApi.src.Persistence.Configurations;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
  public void Configure(EntityTypeBuilder<Album> builder)
  {
    builder.Property(e => e.Title).HasColumnType("varchar").HasMaxLength(250).IsRequired();
    builder.Property(e => e.ReleaseDate).HasColumnType("datetime").IsRequired();
    builder.HasOne(e => e.Artist).WithMany(e => e.Albums).HasForeignKey(e => e.ArtistId);
    builder.HasMany(e => e.Genres);
  }
}
