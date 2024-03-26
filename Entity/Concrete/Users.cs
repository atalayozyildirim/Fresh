using Core.DataAccsess;
using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete
{
    public class Users : IdentityUser, IEntity
    {
        public string RefreshToken { get; set; }
    }
}
