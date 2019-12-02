using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowAutoApp.Core.Infrastructure.Pagination;
using WowAutoApp.Core.Interfaces;
using System.Linq.Expressions;
using WowAutoApp.Core.Domain.TableFilter;

namespace WowAutoApp.Core.Repo
{
    public interface IRepository<T> where T : IEntity
    {
        #region Methods

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        /// <summary>
		/// Get entity by identifier
		/// </summary>
		/// <param name="id">Identifier</param>
		/// <returns>Entity</returns>
		T GetById(object id);

        /// <summary>
		/// Get entity by identifier
		/// </summary>
		/// <param name="id">Identifier</param>
		/// <returns>Entity</returns>
        Task<T> GetByIdAsync(object id);

        /// <summary>
        /// Search by query
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<PagedListResult<T>> SearchAsync(SearchQuery<T> searchQuery);

        /// <summary>
        /// Queryable search by query and definded sequence
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        QueryableSequenceResult<T> GetQueryableSquenceBySearchQuery(SearchQuery<T> searchQuery, IQueryable<T> sequence);
        /// <summary>
        /// Search by query and definded sequence
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        Task<PagedListResult<T>> SearchBySquenceAsync(SearchQuery<T> searchQuery, IQueryable<T> sequence);
        IQueryable<T> GetFilteredSequence(SearchQuery<T> searchQuery, IQueryable<T> sequence);

        SearchQuery<T> GenerateQuery(TableFilter tableFilter, string includeProperties = null);

        /// <summary>
        /// Tracked save changes entities
        /// </summary>
        void TrackedSaveChanges();

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<T> entities);

        bool Any(Expression<Func<T, bool>> expression);

        T FirstOrDefault(Expression<Func<T, bool>> expression);

        T LastOrDefault(Expression<Func<T, bool>> expression);
        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        #endregion
    }
}