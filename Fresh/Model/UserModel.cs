namespace Fresh.Model;

public class UserModel
{
    public string id { get; set; }
    public string Email {
        get;
        set;
    }
    public string UserName { get; set; }
    public string  phoneNumber { get; set; }
    public string normalizedEmail { get; set; }
    public string emailConfrimed{ get; set; }
    public int accessFailedCount { get; set; }
    public string phoneNumberConfirmed { get; set; }
    public string twoFactorEnabled { get; set; }
    public string lockoutEnd { get; set; }
    public string lockoutEnabled { get; set; }
    
}