using System.Linq.Expressions;
using Core.DataAccsess;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace DataAccsess.Concrete.EntityFramework;

public class EfCommentDal : EfRepositoryBase<Comment, Context>;
