using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ceresis.Service.Core.Ext
{
    public static class EnumerableExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> input)
        {
            return input == null || !input.Any();
        }

        public static IQueryable<T> WhereIfNotNull<T>(this DbSet<T> input, string value, Expression<Func<T, bool>> expression) where T : class
        {
            if (string.IsNullOrEmpty(value))
                return input;

            return input.Where(expression);
        }
    }
}
