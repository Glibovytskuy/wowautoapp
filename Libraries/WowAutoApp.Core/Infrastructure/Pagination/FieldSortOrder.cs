using System;
using System.Linq;
using WowAutoApp.Core.Domain.Enums;
using WowAutoApp.Core.Extension;

namespace WowAutoApp.Core.Infrastructure.Pagination
{
    /// <summary>
    /// Represents a sort expression where a property of the sequence item is sorted upon.
    /// Useful to avoid case statement when doing "simple" sorts by "simple" property.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FieldSortOrder<T> : ISortCriteria<T> where T : class
    {
        public String Name { get; set; }

        public OrderType Direction { get; set; }

        public FieldSortOrder()
        {
            Direction = OrderType.Ascending;
        }

        public FieldSortOrder(string name, OrderType direction)
        {
            Name = name;
            Direction = direction;
        }

        public IOrderedQueryable<T> ApplyOrdering(IQueryable<T> qry, Boolean useThenBy)
        {
            IOrderedQueryable<T> result;
            var descending = Direction == OrderType.Descending;
            result = !useThenBy ? qry.OrderBy(Name, descending) : qry.ThenBy(Name, descending);
            return result;
        }
    }
}