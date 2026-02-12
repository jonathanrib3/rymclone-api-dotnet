using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RymCloneApi.src.Domain;

namespace RymCloneApi.src.Persistence.Configurations;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
  public void Configure(EntityTypeBuilder<Album> builder)
  {
    builder.ToTable("albums");
    builder.Property(e => e.Id).HasColumnName("id");
    builder
      .Property(e => e.Title)
      .HasColumnName("title")
      .HasColumnType("varchar")
      .HasMaxLength(250)
      .IsRequired();
    builder
      .Property(e => e.ReleaseDate)
      .HasColumnName("release_date")
      .HasColumnType("date")
      .IsRequired();
    builder.Property(e => e.ArtistId).HasColumnName("artist_id");
    builder.HasOne(e => e.Artist).WithMany(e => e.Albums).HasForeignKey(e => e.ArtistId);
    //builder.HasMany(e => e.Genres).WithMany(g => g.Albums).UsingEntity(ag =>
    //{
    //  ag.ToTable("albums_genres");
    //  ag.Property<int>("AlbumId").HasColumnName("album_id");
    //  ag.Property<int>("GenreId").HasColumnName("genre_id");
    //});
    //builder.HasMany(e => e.Genres).WithMany(a => a.Albums).UsingEntity(
    //  "albums_genres",
    //  l => l.HasOne(nameof(Genre)).WithMany().HasForeignKey().OnDelete(DeleteBehavior.Restrict),
    //  r => r.HasOne(nameof(Album)).WithMany().HasForeignKey("album_id")
    //  );
  }
}
