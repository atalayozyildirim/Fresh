using System.Linq.Expressions;
using Core.DataAccsess;
using Entity.Concrete;

namespace DataAccsess.Abstract;

public interface IUserDal:IEntityFrameworkRepository<Users>
{
  
}