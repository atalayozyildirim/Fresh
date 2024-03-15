using Core.DataAccsess;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfUserDal : EfRepositoryBase<Users, Context>, IUserDal
{
    public EfUserDal(Context context) : base(context)
    {
    }
}