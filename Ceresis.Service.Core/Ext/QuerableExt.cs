using Ceresis.Data.Core.Model;
using Ceresis.Data.Core.Model.Paging;
using Ceresis.Data.Core.Model.Sorting;
using Ceresis.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ceresis.Service.Core.Ext
{
    public static class QuerableExt
    {
        public static IOrderedQueryable<T> Sorting<T>(this IQueryable<T> items, ISorting sort) where T: BaseIntEntity
        {
            if (sort == null)
                return items.OrderBy(i => i.Id);

            var exp = GetSortOrder<T>(sort.Name);

            switch (sort.Direction)
            {
                case "asc":
                    return items.OrderBy(exp);
                case "desc":
                    return items.OrderByDescending(exp);
                default:
                    return items.OrderBy(i => i.Id);
            }
        }

        public static IQueryable<T> Pagination<T>(this IOrderedQueryable<T> items, IPaging pagination)
        {
            if (pagination == null) return items;

            pagination.Length = 0;
            if (items == null || !items.Any()) return items;

            var skip = pagination.Page == 0 ? 0 : pagination.Page;

            pagination.Length = items.Count();

            return items.Skip(skip * pagination.PageSize).Take(pagination.PageSize);
        }

        private static Expression<Func<T, object>> GetSortOrder<T>(string name) where T : BaseIntEntity
        {
            Expression<Func<T, object>> exp = l => l.Id;

            if (string.IsNullOrEmpty(name)) return exp;

            var matchedProperty = typeof(T).GetProperties().FirstOrDefault(p => p.Name.ToUpper() == name.ToUpper());

            if (matchedProperty == null) return exp;

            return l => matchedProperty.Name;
        }
    }
}
