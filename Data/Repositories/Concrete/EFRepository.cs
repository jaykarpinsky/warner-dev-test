using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using WarnerTestJK.Data.Models;
using WarnerTestJK.Data.Repositories.Abstract;
using System.Threading.Tasks;

namespace WarnerTestJK.Data.Repositories.Concrete
{

    /// <summary>
    /// Gereric Repository for read operations using Entity Framework; T must implement BaseEntity (i.e. int Id as a PK)
    /// </summary>
    public class EfRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        protected readonly AppDBContext _dbContext;

        public EfRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region "Regular Calls"

        /// <summary>
        /// Gets an object by it's Id
        /// </summary>
        public T GetById(int id)
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Gets a list of all objects in the datastore
        /// </summary>
        public virtual IQueryable<T> List()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Gets a list filtered and sorted objects that can include related objects
        /// </summary>
        /// <param name="filter">An expression to filter the data</param>
        /// <param name="orderBy">Sets the column to order by</param>
        /// <param name="includeProperties">A list of related objects to include in the query</param>
        public virtual IQueryable<T> List(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, string includeProperties = null)  //
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (string IncludeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProperty);
                }
            }

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            return query;
        }

        /// <summary>
        /// Overload for the List method
        /// </summary>
        /// <param name="filter">An expression to filter the data</param>
        public virtual IQueryable<T> List(Expression<Func<T, bool>> filter)
        {
            return this.List(filter, null, null);
        }

        /// <summary>
        /// Overload for the List method
        /// </summary>
        /// <param name="filter">An expression to filter the data</param>
        /// <param name="includeProperties">A list of related objects to include in the query</param>
        public virtual IQueryable<T> List(Expression<Func<T, bool>> filter, string includeProperties)
        {
            return this.List(filter, null, includeProperties);
        }

        #endregion

        #region "Async Methods"

        /// <summary>
        /// Asynchronously gets an object by it's Id
        /// </summary>
        public Task<T> GetByIdAsync(int id)
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Asynchronously gets a list of all objects in the datastore
        /// </summary>
        public async Task<List<T>> ListAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Asynchronously gets a list filtered and sorted objects that can include related objects
        /// </summary>
        /// <param name="filter">An expression to filter the data</param>
        /// <param name="orderBy">Sets the column to order by</param>
        /// <param name="includeProperties">A list of related objects to include in the query</param>
        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, string includeProperties = null)  //
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (string IncludeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProperty);
                }
            }

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Overload for the ListAsync method
        /// </summary>
        /// <param name="filter">An expression to filter the data</param>
        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await this.ListAsync(filter, null, null);
        }

        /// <summary>
        /// Overload for the ListAsync method
        /// </summary>
        /// <param name="filter">An expression to filter the data</param>
        /// <param name="includeProperties">A list of related objects to include in the query</param>
        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> filter, string includeProperties)
        {
            return await this.ListAsync(filter, null, includeProperties);
        }

        #endregion
    }
}
