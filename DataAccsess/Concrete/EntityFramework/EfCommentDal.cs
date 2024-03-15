using Core.DataAccsess;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfCommentDal : EfRepositoryBase<Comment, Context>, ICommentDal
{
    // EfCommentDal sınıfının bir yapıcısı (constructor) bulunmaktadır.
    // Bu yapıcı, Context tipinde bir parametre alır ve bu parametreyi base(context) ile temel sınıfa yani EfRepositoryBase<Comment,Context> sınıfına gönderir.
    // Bu, EfRepositoryBase<Comment,Context> sınıfının yapıcısının Context tipinde bir parametre beklediği ve bu parametrenin veritabanı bağlamını temsil ettiği anlamına gelir. 
    public EfCommentDal(Context context) : base(context)
    {
    }
}
