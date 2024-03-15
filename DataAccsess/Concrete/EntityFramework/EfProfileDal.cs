using Core.DataAccsess;
using DataAccsess.Abstract;
using Entity.Abstract;
using Entity.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfProfileDal: EfRepositoryBase<Profile,Context> ,IProfile, IProfilDal
{
    public EfProfileDal(Context context) : base(context)
    {
    }
    
}