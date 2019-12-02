using System.Linq;
using WowAutoApp.Core.Domain.Enums;

namespace WowAutoApp.Core.Infrastructure.Pagination
{
    public interface ISortCriteria<T>
    {
        OrderType Direction { get; set; }

        IOrderedQueryable<T> ApplyOrdering(IQueryable<T> query, bool useThenBy);
    }
}