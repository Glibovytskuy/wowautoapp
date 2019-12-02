using System;
using System.Linq;
using System.Linq.Expressions;
using WowAutoApp.Core.Domain.Enums;

namespace WowAutoApp.Core.Infrastructure.Pagination
{
    public class ExpressionSortCriteria<T, TKey> : ISortCriteria<T>
    {
        public Expression<Func<T, TKey>> SortExpression { get; set; }

        public OrderType Direction { get; set; }

        public ExpressionSortCriteria()
        {
            Direction = OrderType.Ascending;
        }

        public ExpressionSortCriteria(OrderType direction, Expression<Func<T, TKey>> sortExpression)
        {
            Direction = direction;
            SortExpression = sortExpression;
        }

        /// <summary>
        /// If the "name" value has an " asc" or " desc" on the end, 
        /// the Direction property will be set accordinly.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="useThenBy"></param>
        public IOrderedQueryable<T> ApplyOrdering(IQueryable<T> query, Boolean useThenBy)
        {
            IOrderedQueryable<T> result;
            if (SortExpression != null)
            {
                if (Direction == OrderType.Ascending)
                {
                    result = !useThenBy ? query.OrderBy(SortExpression) : ((IOrderedQueryable<T>)query).ThenBy(SortExpression);
                }
                else
                {
                    result = !useThenBy ? query.OrderByDescending(SortExpression) : ((IOrderedQueryable<T>)query).ThenBy(SortExpression);
                }
            }
            else
            {
                return query.OrderBy(x => x);
            }
            return result;
        }
    }
}