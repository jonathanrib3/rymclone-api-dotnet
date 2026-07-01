namespace RymCloneApi.src.Controllers.v1.DTOs.AlbumsDTOs
{
  public class AlbumArtistResponseDTO
  {
    public int? Id { get; set; }
    public String? Name { get; set; }
  }
  public class AlbumGenreResponseDTO
  { 
    public int? Id { get; set; }
    public String? Name { get; set; }
  }
  public class AlbumResponseDTO
  {
    public int? Id { get; set; }
    public String? Title { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public AlbumArtistResponseDTO? Artist { get; set; }
    public IEnumerable<AlbumGenreResponseDTO>? Genres { get; set; }
  }
}
