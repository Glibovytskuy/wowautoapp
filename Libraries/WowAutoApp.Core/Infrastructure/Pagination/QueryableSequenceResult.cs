using System.Linq;

namespace WowAutoApp.Core.Infrastructure.Pagination
{
    /// <summary>
    /// Used as a return value for methods executing queries.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class QueryableSequenceResult<TEntity>
    {
        /// <summary>
        /// Result of the query.
        /// </summary>
        public IQueryable<TEntity> QueryableEntities { get; set; }
    }
}