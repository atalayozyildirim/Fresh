using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccsess
{
    public class EfRepositoryBase<TEntity, TContext> : IEntityFrameworkRepository<TEntity>
            where TEntity : class, IEntity, new()
            where TContext : DbContext
    {
        private readonly TContext _context;

        public EfRepositoryBase(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>()
                            .Take(10)
                            .ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity GetById(string id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            // Handle the retrieved entity...
            return entity;
        }



    }
}