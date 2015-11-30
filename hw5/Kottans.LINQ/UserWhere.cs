using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kottans.LINQ
{
    public static class UserWhere
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
          Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();
            return Iterator(source, predicate);
        }

        public static IEnumerable<TSource> Iterator<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var v in source)
            {
                if (predicate(v))
                    yield return v;
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            return Iterator(source, predicate);
        }

        public static IEnumerable<TSource> Iterator<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int i = 0;

            foreach (var v in source)
            {
                if (predicate(v, i++))
                    yield return v;
            }
        }
    }
}
