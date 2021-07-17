using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WarnerTestJK.Data.Models;
using System.Threading.Tasks;

namespace WarnerTestJK.Data.Repositories.Abstract
{
    /// <summary>
    /// Iterface for read opertions to the datastore, can be combined with other interfaces for full CRUD operations
    /// </summary>
    public interface IReadOnlyRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IQueryable<T> List();
        IQueryable<T> List(Expression<Func<T, bool>> filter);
        IQueryable<T> List(Expression<Func<T, bool>> filter, string includeProperties);
        IQueryable<T> List(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, string includeProperties = null);

        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter, string includeProperties);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, string includeProperties = null);


    }
}
