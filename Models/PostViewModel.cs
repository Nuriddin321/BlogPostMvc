
namespace BlogMvc.Models;

public class PostViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public string AppUserId { get; set; }
    public string Author { get; set; }
    public string AuthorImage { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsEdited { get; set; }
}