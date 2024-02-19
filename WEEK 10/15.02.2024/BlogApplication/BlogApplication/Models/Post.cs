namespace BlogApplication.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime? CreatedDate { get; set; } = DateTime.Now;


    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Image>? Images { get; set; }

} 
