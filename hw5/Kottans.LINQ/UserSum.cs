using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class UserSum
    {
        public static int Sum(this System.Collections.Generic.IEnumerable<int> source)
        {
            if (source == null) throw new ArgumentNullException();
            int result = 0;
            foreach (var v in source)
            {
                result += v;
            }
            return result;
        }

        public static int? Sum(this System.Collections.Generic.IEnumerable<int?> source)
        {
            if (source == null) throw new ArgumentNullException();
            int? result = 0;
            foreach (var v in source)
            {
                result += v;
            }
            return result;
        }



        public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }
        //
        public static int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }
    }
}
