using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RymCloneApi.src.Persistence.Context.Extensions
{
  public static class DataAccessExtensions
  {
    public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> currentQuery, params Expression<Func<T, object>>[] includes) where T : class
    {
      var query = currentQuery;
      foreach (var include in includes)
      {
        query = query.Include(include);
      }

      return query;
    }
  }
}
