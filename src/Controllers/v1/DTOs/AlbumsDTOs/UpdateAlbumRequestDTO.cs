namespace RymCloneApi.src.Controllers.v1.DTOs.AlbumsDTOs
{
  public class UpdateAlbumRequestDTO
  {
    public String? Title { get; set; }
    public DateTime? ReleaseDate {  get; set;  }
    public int? ArtistId { get; set; }
    public IEnumerable<int>? GenresIds { get; set; }
  }
}
