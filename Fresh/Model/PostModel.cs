using System.ComponentModel.DataAnnotations;

namespace Fresh.Model;

public class PostModel
{

    public string id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    
    public DateTime CreateDate { get; set; }
    
    public string url { get; set; }
    public string image { get; set; }
    
    public string user_id { get; set; }
}