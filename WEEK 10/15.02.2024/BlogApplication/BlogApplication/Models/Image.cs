namespace BlogApplication.Models;

public class Image
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;

    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}