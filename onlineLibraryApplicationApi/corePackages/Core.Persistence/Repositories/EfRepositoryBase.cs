using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (predicate != null) queryable = queryable.Where(predicate);
            return await queryable.ToListAsync();
        }

        //public async Task<TEntity> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
        //                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        //                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        //                                        bool enableTracking = true)
        //{
        //    IQueryable<TEntity> queryable = Query();
        //    if (!enableTracking) queryable = queryable.AsNoTracking();
        //    if (include != null) queryable = include(queryable);
        //    if (predicate != null) queryable = queryable.Where(predicate);
        //    if (orderBy != null)
        //        return await orderBy(queryable);
        //    return (TEntity)(IQueryable<TEntity>)await queryable.ToListAsync();
        //}

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
