using Core.DataAccsess;
using Entity.Abstract;

namespace Entity.Concrete;

public class Profile: IProfile, IEntity
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Content { get; set; }
    public string Link_Account_URI { get; set; }
    public string ProfileImage { get; set; }
}