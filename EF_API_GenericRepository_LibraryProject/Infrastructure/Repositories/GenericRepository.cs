using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null) 
            { 
                _dbSet.Remove(entity);
                _appDbContext.SaveChanges();
            }
        }

        public bool DoesItemExist(int id)
        {
            return _dbSet.Find(id) != null;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();

        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

    }
}
