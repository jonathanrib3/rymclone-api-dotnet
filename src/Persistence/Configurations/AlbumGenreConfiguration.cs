using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RymCloneApi.src.Domain;

namespace RymCloneApi.src.Persistence.Configurations;

public class AlbumGenreConfiguration : IEntityTypeConfiguration<AlbumGenre>
{
  public void Configure(EntityTypeBuilder<AlbumGenre> builder)
  {
    builder.ToTable("albums_genres");
    builder.Property(e => e.AlbumId).HasColumnName("album_id");
    builder.Property(e => e.GenreId).HasColumnName("genre_id");
  }
}
