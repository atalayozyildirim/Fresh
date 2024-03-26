using System.ComponentModel.DataAnnotations;

namespace Fresh.Model;

public class TokenModel
{
    public string RefreshToken { get; set; }
}