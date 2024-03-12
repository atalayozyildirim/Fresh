using System.ComponentModel.DataAnnotations;

namespace Fresh.Model;

public class PostModel
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public string userId { get; set; }
    
    
}