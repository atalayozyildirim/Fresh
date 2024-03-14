using System.Linq.Expressions;
using Core.DataAccsess;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfLikeDal : EfRepositoryBase<Likes,Context>
{
    public EfLikeDal(Context context) : base(context)
    {
    }
}
