using Core.DataAccsess;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfLikeDal : EfRepositoryBase<Likes, Context>, ILikeDal
{
    public EfLikeDal(Context context) : base(context)
    {
    }
}
