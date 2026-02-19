namespace RymCloneApi.src.Domain.DTOs.v1
{
  public class CreateAlbumRequestDTO
  {
    public String Title { get; set; }
    public DateTime ReleaseDate {  get; set;  }
    public int ArtistId { get; set; }
    public int[] GenresIds { get; set; }
  }
}
