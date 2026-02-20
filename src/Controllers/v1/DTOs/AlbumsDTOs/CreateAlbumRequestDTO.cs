namespace RymCloneApi.src.Controllers.v1.DTOs.AlbumsDTOs
{
  public class CreateAlbumRequestDTO
  {
    public String Title { get; set; }
    public DateTime ReleaseDate {  get; set;  }
    public int ArtistId { get; set; }
    public int[] GenresIds { get; set; }
  }
}
