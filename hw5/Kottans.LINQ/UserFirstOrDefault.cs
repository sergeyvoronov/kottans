using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kottans.LINQ
{
    public static class UserFirstOrDefault
    {
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();

            IEnumerator<TSource> enumerator = source.GetEnumerator();
            if (enumerator.MoveNext()) return enumerator.Current;

            return default(TSource);
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            foreach (var v in source)
            {
                if (predicate(v)) return v;
            }

            return default(TSource);
        }
    }
}
