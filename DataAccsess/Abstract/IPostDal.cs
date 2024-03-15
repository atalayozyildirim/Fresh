using Core.DataAccsess;
using Entity.Concrete;

namespace DataAccsess.Abstract;

public interface IPostDal : IEntityFrameworkRepository<Post>
{

}