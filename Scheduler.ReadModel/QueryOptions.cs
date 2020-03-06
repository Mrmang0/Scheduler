using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Scheduler.ReadModel
{
    public class QueryOptions<T>
    {
        public QueryOptions()
        {
            Fields = new List<Expression<Func<T, object>>>();
        }

        public static QueryOptions<T> Empty { get; } = new QueryOptions<T>();

        public int? Skip { get; set; }

        public int? Take { get; set; }

        public IEnumerable<Expression<Func<T, object>>> Fields { get; set; }

        public string SortAscending { get; set; }

        public string SortDescending { get; set; }
    }

    public static class QueryOptionsExtension
    {
        public static QueryOptions<T> Include<T>(this QueryOptions<T> options, params Expression<Func<T, object>>[] fields)
        {
            var result = new List<Expression<Func<T, object>>>();

            foreach (var field in fields)
            {
                result.Add(field);
            }
            options.Fields = result;
            return options;
        }

        public static QueryOptions<T> Skip<T>(this QueryOptions<T> options, int skip)
        {
            options.Skip = skip;
            return options;
        }

        public static QueryOptions<T> Take<T>(this QueryOptions<T> options, int take)
        {
            options.Take = take;
            return options;
        }
    }
}
