using Core.DataAccsess;
using Entity.Concrete;

namespace DataAccsess.Abstract;

public interface ICommentDal:IEntityFrameworkRepository<Comment>
{
    
}