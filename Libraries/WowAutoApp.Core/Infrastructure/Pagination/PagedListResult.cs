﻿using System.Collections.Generic;

namespace WowAutoApp.Core.Infrastructure.Pagination
{
    /// <summary>
    /// Used as a return value for methods executing queries.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PagedListResult<TEntity>
    {
        /// <summary>
        /// Does the returned result contains more rows to be retrieved?
        /// </summary>
        public bool HasNext { get; set; }

        /// <summary>
        /// Does the returned result contains previous items ?
        /// </summary>
        public bool HasPrevious { get; set; }

        /// <summary>
        /// Total number of rows that could be possibly be retrieved.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Result of the query.
        /// </summary>
        public IEnumerable<TEntity> Entities { get; set; }
    }
}