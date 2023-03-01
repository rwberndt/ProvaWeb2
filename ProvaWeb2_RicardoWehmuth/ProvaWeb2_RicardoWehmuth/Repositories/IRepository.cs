namespace ProvaWeb2_RicardoWehmuth.Repositories
{
    public interface IRepository<TEntity>
    {
        public void Insert(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public TEntity Find(int id);
        public IQueryable<TEntity> GetAll();
    }
}
