using System;
using System.Collections.Generic;


namespace Kottans.LINQ
{
    public static class UserSelect
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
                   Func<TSource, TResult> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            return Iterator(source, predicate);
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            return Iterator(source, predicate);
        }

        private static IEnumerable<TResult> Iterator<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> predicate)
        {
            foreach (var v in source)
                yield return predicate(v);
        }

        private static IEnumerable<TResult> Iterator<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> predicate)
        {
            int i = 0;

            foreach (var v in source)
                yield return predicate(v, i++);
        }



    }
}
