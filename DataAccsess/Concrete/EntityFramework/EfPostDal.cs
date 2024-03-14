using System.Linq.Expressions;
using Core.DataAccsess;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfPostDal : EfRepositoryBase<Post,Context>, IPostDal
{
    public EfPostDal(Context context) : base(context)
    {
    }
}
