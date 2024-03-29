﻿using System.ComponentModel.DataAnnotations;

namespace Fresh.Model;

public class PostModel
{

    public string id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public string user_id { get; set; }
}