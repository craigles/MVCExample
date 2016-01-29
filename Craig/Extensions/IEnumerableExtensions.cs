using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using Craig.Models.Movies;

namespace Craig.Extensions
{
    public static class EnumerableExtensions
    {
        private static readonly Dictionary<string, Func<MovieModel, object>> SortKey = new Dictionary<string, Func<MovieModel, object>>
        {
            {"Title", model => model.Title},
            {"Classification", model => model.Classification},
            {"ReleaseDate", model => model.ReleaseDate},
            {"Rating", model => model.Rating}
        }; 

        public static IEnumerable<T> ApplyPaging<T>(this IEnumerable<T> list, int pageSize, int page)
        {
            var numberOfItemsToSkip = page * pageSize - pageSize;

            return list
                .Skip(numberOfItemsToSkip)
                .Take(pageSize);
        }

        public static int NumberOfPages<T>(this IEnumerable<T> list, int pageSize)
        {
            return (int) Math.Ceiling(decimal.Divide(list.Count(), pageSize));
        }

        public static IEnumerable<MovieModel> Sort(this IEnumerable<MovieModel> list, SortDirection sortDirection, string column)
        {
            if (!SortKey.ContainsKey(column))
                return list.OrderBy(SortKey.Values.First());

            if (sortDirection == SortDirection.Ascending)
                return list.OrderBy(SortKey[column]);

            return list.OrderByDescending(SortKey[column]);
        } 
    }
}