using Core.DataAccsess;
using DataAccsess.Abstract;
using Entity.Concrete;
using System.Linq.Expressions;

namespace DataAccsess.Concrete.EntityFramework;

public class EfUserDal:EfRepositoryBase<Users,Context>,IUserDal;