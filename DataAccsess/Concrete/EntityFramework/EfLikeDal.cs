using Core.DataAccsess;
using Entity.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfLikeDal : EfRepositoryBase<Likes, Context>
{
    public EfLikeDal(Context context) : base(context)
    {
    }
}
