using System.Linq.Expressions;

namespace Core.DataAccsess;

public interface IEntityFrameworkRepository<TEntity> where TEntity : IEntity, new()
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    // Kullanıcı isterse filtreme yapabilir
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    // kullancı  = null olmadıgı için boş geçemez filtre yapmalı
    TEntity Get(Expression<Func<TEntity, bool>> filter);
    void GetById(int id);


}  