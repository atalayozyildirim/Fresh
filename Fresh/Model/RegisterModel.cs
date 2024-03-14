using System.ComponentModel.DataAnnotations;

namespace Fresh.Model;

public class RegisterModel
{

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]  
    [MaxLength(20)]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [Required]
    public string? UserName { get; set; }

    [Phone]
    public string phoneNumber { get; set; }
}

