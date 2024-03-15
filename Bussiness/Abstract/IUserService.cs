using Entity.Concrete;

namespace Bussnies.Abstract;

public interface IUserService
{
  Task<Users> GetUserById();
}