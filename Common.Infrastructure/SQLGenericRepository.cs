using Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure
{
    public class SQLGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public SQLGenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var result = _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity?> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity? GetEntity()
        {
            return _dbContext.Set<TEntity>().FirstOrDefault();
        }


        
    }



}
