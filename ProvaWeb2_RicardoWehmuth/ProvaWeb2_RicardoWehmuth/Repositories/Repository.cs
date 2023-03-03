using Microsoft.EntityFrameworkCore;
using ProvaWeb2_RicardoWehmuth.Context;
using ProvaWeb2_RicardoWehmuth.Models;

namespace ProvaWeb2_RicardoWehmuth.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly ComandaContext _context;

        public Repository(ComandaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(TEntity entity)
        {

            _context.Database.BeginTransaction();
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public TEntity? Find(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public void Insert(TEntity entity)
        {
            _context.Database.BeginTransaction();
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void Update(TEntity entity)
        {
            _context.Database.BeginTransaction();
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

    }
}
