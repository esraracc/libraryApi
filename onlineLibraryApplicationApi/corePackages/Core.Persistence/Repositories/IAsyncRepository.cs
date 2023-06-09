﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<T> : IQuery<T> where T : Entity
    {
        Task<T> GetAsync(Expression<Func<T, bool>>? predicate = null);
        Task<IEnumerable<T>> GetAllListAsync(Expression<Func<T, bool>>? predicate = null);

        //Task<T> GetListAsync(Expression<Func<T, bool>>? predicate = null,
        //                              Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        //                              Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        //                              int index = 0, int size = 10, bool enableTracking = true);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
