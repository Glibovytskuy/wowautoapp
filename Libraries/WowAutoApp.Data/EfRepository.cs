using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WowAutoApp.Core.Domain.TableFilter;
using WowAutoApp.Core.Infrastructure.Pagination;
using WowAutoApp.Core.Interfaces;
using WowAutoApp.Core.Repo;
using WowAutoApp.Data.Interfaces;

namespace WowAutoApp.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Fields

        private readonly IDbContext _context;

        private DbSet<TEntity> _entities;

        #endregion

        #region Ctor

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Error message</returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry => entry.State = EntityState.Unchanged);
            }

            _context.SaveChanges();
            return exception.ToString();
        }

        #endregion

        #region Methods

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return Entities.Where(expression);
        }


        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        /// <summary>
        /// Search by query and defined sequence
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        /// <summary>
        /// Executes the query against the repository (database).
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected QueryableSequenceResult<TEntity> GetQueryableSequenceResult(SearchQuery<TEntity> searchQuery, IQueryable<TEntity> sequence)
        {
            var result = searchQuery.Take > 0
                                ? (sequence.Skip(searchQuery.Skip).Take(searchQuery.Take))
                                : sequence;

            // Setting up the return object.
            return new QueryableSequenceResult<TEntity>()
            {
                QueryableEntities = result
            };
        }
        /// <summary>
        /// Search by query and defined sequence
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public QueryableSequenceResult<TEntity> GetQueryableSquenceBySearchQuery(SearchQuery<TEntity> searchQuery, IQueryable<TEntity> sequence)
        {
            //Applying filters
            if (searchQuery.Filters.Any())
                sequence = ManageFilters(searchQuery, sequence);

            //Include Properties
            if (!string.IsNullOrWhiteSpace(searchQuery.IncludeProperties))
                sequence = ManageIncludeProperties(searchQuery, sequence);

            //Resolving Sort Criteria
            //This code applies the sorting criterias sent as the parameter
            sequence = ManageSortCriterias(searchQuery, sequence);

            return GetQueryableSequenceResult(searchQuery, sequence);
        }

        /// <summary>
        /// Search by query
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public async Task<PagedListResult<TEntity>> SearchAsync(SearchQuery<TEntity> searchQuery)
        {
            IQueryable<TEntity> sequence = Entities;

            //Applying filters
            if (searchQuery.Filters != null && searchQuery.Filters.Count > 0)
                sequence = ManageFilters(searchQuery, sequence);

            //Include Properties
            if (!string.IsNullOrWhiteSpace(searchQuery.IncludeProperties))
                sequence = ManageIncludeProperties(searchQuery, sequence);

            //Resolving Sort Criteria
            //This code applies the sorting criterias sent as the parameter
            sequence = ManageSortCriterias(searchQuery, sequence);

            return await GetTheResult(searchQuery, sequence);
        }

        /// <summary>
        /// Search by query and defined sequence
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public async Task<PagedListResult<TEntity>> SearchBySquenceAsync(SearchQuery<TEntity> searchQuery, IQueryable<TEntity> sequence)
        {
            //Applying filters
            if (searchQuery.Filters != null && searchQuery.Filters.Count > 0)
                sequence = ManageFilters(searchQuery, sequence);

            //Include Properties
            if (!string.IsNullOrWhiteSpace(searchQuery.IncludeProperties))
                sequence = ManageIncludeProperties(searchQuery, sequence);

            //Resolving Sort Criteria
            //This code applies the sorting criterias sent as the parameter
            sequence = ManageSortCriterias(searchQuery, sequence);

            return await GetTheResult(searchQuery, sequence);
        }

        public IQueryable<TEntity> GetFilteredSequence(SearchQuery<TEntity> searchQuery, IQueryable<TEntity> sequence)
        {
            //Applying filters
            if (searchQuery.Filters != null && searchQuery.Filters.Count > 0)
                sequence = ManageFilters(searchQuery, sequence);

            //Resolving Sort Criteria
            //This code applies the sorting criterias sent as the parameter
            sequence = ManageSortCriterias(searchQuery, sequence);

            return sequence;
        }

        public SearchQuery<TEntity> GenerateQuery(TableFilter tableFilter, string includeProperties = null)
        {
            var query = new SearchQuery<TEntity>
            {
                Skip = tableFilter.Start,
                Take = tableFilter.Length,
                IncludeProperties = includeProperties
            };

            query.AddSortCriteria(new FieldSortOrder<TEntity>(tableFilter.ColumnName, tableFilter.OrderType));

            return query;
        }

        /// <summary>
        /// Executes the query against the repository (database).
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected async Task<PagedListResult<TEntity>> GetTheResult(SearchQuery<TEntity> searchQuery, IQueryable<TEntity> sequence)
        {
            //Counting the total number of object.
            var resultCount = await sequence.CountAsync();

            var result = (searchQuery.Take > 0)
                                ? await (sequence.Skip(searchQuery.Skip).Take(searchQuery.Take).ToListAsync())
                                : await (sequence.ToListAsync());

            //Debug info of what the query looks like
            //Console.WriteLine(sequence.ToString());

            // Setting up the return object.
            bool hasNext = (searchQuery.Skip > 0 || searchQuery.Take > 0) && (searchQuery.Skip + searchQuery.Take < resultCount);
            return new PagedListResult<TEntity>()
            {
                Entities = result,
                HasNext = hasNext,
                HasPrevious = (searchQuery.Skip > 0),
                Count = resultCount
            };
        }

        /// <summary>
        /// Resolves and applies the sorting criteria of the SearchQuery
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected IQueryable<TEntity> ManageSortCriterias(SearchQuery<TEntity> searchQuery, IQueryable<TEntity> sequence)
        {
            if (searchQuery.SortCriterias != null && searchQuery.SortCriterias.Count > 0)
            {
                var sortCriteria = searchQuery.SortCriterias[0];
                var orderedSequence = sortCriteria.ApplyOrdering(sequence, false);

                if (searchQuery.SortCriterias.Count > 1)
                {
                    for (var i = 1; i < searchQuery.SortCriterias.Count; i++)
                    {
                        var sc = searchQuery.SortCriterias[i];
                        orderedSequence = sc.ApplyOrdering(orderedSequence, true);
                    }
                }
                sequence = orderedSequence;
            }
            else
            {
                sequence = ((IOrderedQueryable<TEntity>)sequence).OrderBy(x => (true));
            }
            return sequence;
        }

        /// <summary>
        /// Chains the where clause to the IQueriable instance.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected IQueryable<TEntity> ManageFilters(SearchQuery<TEntity> searchQuery, IQueryable<TEntity> sequence)
        {
            foreach (var filterClause in searchQuery.Filters)
            {
                sequence = sequence.Where(filterClause);
            }

            return sequence;
        }

        /// <summary>
        /// Includes the properties sent as part of the SearchQuery.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected IQueryable<TEntity> ManageIncludeProperties(SearchQuery<TEntity> searchQuery, IQueryable<TEntity> sequence)
        {
            var properties = searchQuery.IncludeProperties.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var includeProperty in properties)
            {
                sequence = sequence.Include(includeProperty);
            }

            return sequence;
        }

        /// <summary>
        /// Tracked save changes entities
        /// </summary>
        void IRepository<TEntity>.TrackedSaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.AddRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.UpdateRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.RemoveRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return Entities.Any(expression);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return Entities.FirstOrDefault(expression);
        }

        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return Entities.LastOrDefault(expression);
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<TEntity> Table => Entities;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking =>
            //AsNoTracking method temporarily doesn't work, it's a bug in EF Core 2.1 (details in https://github.com/aspnet/EntityFrameworkCore/issues/11689)
            // Update - I checked this functionality and it is working fine, that's why I returned 
            Entities.AsNoTracking();

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

        #endregion
    }
}