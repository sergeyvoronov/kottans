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

            checked
            {
                foreach (var v in source)
                {
                    result += v;
                }
            }
            return result;
        }

        public static int? Sum(this System.Collections.Generic.IEnumerable<int?> source)
        {
            if (source == null) throw new ArgumentNullException();
            int? result = 0;
            checked
            {
                foreach (var v in source)
                {

                    result += v.GetValueOrDefault();
                }
            }
            return result;
        }

       public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }

        public static int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }

        public static long Sum(this IEnumerable<long> source)
        {
            if (source == null) throw new ArgumentNullException();

            var result = 0L;
            checked
            {
                foreach (var i in source)
                {
                    result += i;
                }
            }

            return result;
        }

        public static long? Sum(this IEnumerable<long?> source)
        {
            if (source == null) throw new ArgumentNullException();

            var result = 0L;
            checked
            {
                foreach (var i in source)
                {
                    result += i.GetValueOrDefault();
                }
            }

            return result;
        }

        public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }

        public static long? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }

        public static decimal Sum(this IEnumerable<decimal> source)
        {
            if (source == null) throw new ArgumentNullException();

            var result = 0M;
            checked
            {
                foreach (var i in source)
                {
                    result += i;
                }
            }

            return result;
        }

        public static decimal? Sum(this IEnumerable<decimal?> source)
        {
            if (source == null) throw new ArgumentNullException();

            var result = 0M;
            checked
            {
                foreach (var i in source)
                {
                    result += i.GetValueOrDefault();
                }
            }

            return result;
        }

        public static decimal Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }

        public static decimal? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }

        public static float Sum(this IEnumerable<float> source)
        {
            if (source == null) throw new ArgumentNullException();

            var result = 0D;
            checked
            {
                foreach (var i in source)
                {
                    result += i;
                }
            }

            return (float)result;
        }

        public static float? Sum(this IEnumerable<float?> source)
        {
            if (source == null) throw new ArgumentNullException();

            var result = 0D;
            checked
            {
                foreach (var i in source)
                {
                    result += i.GetValueOrDefault();
                }
            }

            return (float)result;
        }

        public static float Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }

        public static float? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }

        public static double Sum(this IEnumerable<double> source)
        {
            if (source == null) throw new ArgumentNullException();

            var result = 0D;
            checked
            {
                foreach (var i in source)
                {
                    result += i;
                }
            }

            return result;
        }

        public static double? Sum(this IEnumerable<double?> source)
        {
            if (source == null) throw new ArgumentNullException();

            var result = 0D;
            checked
            {
                foreach (var i in source)
                {
                    result += i.GetValueOrDefault();
                }
            }

            return result;
        }

        public static double Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }

        public static double? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            return source.Select(predicate).Sum();
        }
       

    }
}
