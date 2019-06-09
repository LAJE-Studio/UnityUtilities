using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

namespace UnityUtilities
{
    public class ComparableComparer<T> : Comparer<T> where T : IComparable<T>
    {
        public override int Compare(T x, T y)
        {
            if (x == null)
            {
                return y != null ? -1 : 0;
            }

            return y != null ? x.CompareTo(y) : 1;
        }

        public override bool Equals(object obj)
        {
            return obj is ComparableComparer<T>;
        }

        public override int GetHashCode()
        {
            return GetType().Name.GetHashCode();
        }
    }

    public static class CollectionUtil
    {
        public static bool IsEmpty(this IEnumerable enumerable)
        {
            return !enumerable.Cast<object>().Any();
        }

        public static bool IsEmpty(this ICollection collection)
        {
            return collection.Count <= 0;
        }

        public static bool IsNullOrEmpty(this IEnumerable enumerable)
        {
            return enumerable == null || enumerable.IsEmpty();
        }

        public static bool IsNullOrEmpty(this ICollection collection)
        {
            return collection == null || collection.IsEmpty();
        }

        public static T GetOrPut<T>(this ICollection<T> collection, Func<T, bool> predicate, Func<T> instantiator)
        {
            foreach (var obj in collection)
            {
                if (predicate(obj))
                {
                    return obj;
                }
            }

            var newObj = instantiator();
            collection.Add(newObj);
            return newObj;
        }

        public static V GetOrPut<K, V>(this IDictionary<K, V> collection, K key, Func<V> instantiator)
        {
            if (collection.ContainsKey(key))
            {
                return collection[key];
            }

            var newObj = instantiator();
            collection[key] = newObj;
            return newObj;
        }

        public static List<T> GetAllOrPut<T>(
            this ICollection<T> collection,
            Func<T, bool> predicate,
            Func<T> instantiator)
        {
            var list = collection.Where(predicate).ToList();
            if (!list.IsEmpty())
            {
                return list;
            }

            var newObj = instantiator();
            collection.Add(newObj);
            list.Add(newObj);

            return list;
        }

        public static TSource MinBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> selector) where TKey : IComparable<TKey>
        {
            return source.MinBy(selector, Comparer<TKey>.Default);
        }

        public static T MinBy<T, K>(
            this IEnumerable<T> source,
            Func<T, K> selector,
            IComparer<K> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            comparer = comparer ?? Comparer<K>.Default;

            using (var sourceIterator = source.GetEnumerator())
            {
                if (!sourceIterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }

                var min = sourceIterator.Current;
                var minKey = selector(min);
                while (sourceIterator.MoveNext())
                {
                    var candidate = sourceIterator.Current;
                    var candidateProjected = selector(candidate);
                    if (comparer.Compare(candidateProjected, minKey) >= 0)
                    {
                        continue;
                    }

                    min = candidate;
                    minKey = candidateProjected;
                }

                return min;
            }
        }

        public static TSource MaxBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> selector) where TKey : IComparable<TKey>
        {
            return source.MaxBy(selector, Comparer<TKey>.Default);
        }

        public static T MaxBy<T, K>(
            this IEnumerable<T> source,
            Func<T, K> selector,
            IComparer<K> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            comparer = comparer ?? Comparer<K>.Default;

            using (var sourceIterator = source.GetEnumerator())
            {
                if (!sourceIterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }

                var min = sourceIterator.Current;
                var minKey = selector(min);
                while (sourceIterator.MoveNext())
                {
                    var candidate = sourceIterator.Current;
                    var candidateProjected = selector(candidate);
                    if (comparer.Compare(candidateProjected, minKey) <= 0)
                    {
                        continue;
                    }

                    min = candidate;
                    minKey = candidateProjected;
                }

                return min;
            }
        }

        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            var tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }

        public static IEnumerable<T> EmptyEnumerable<T>()
        {
            return Enumerable.Empty<T>();
        }

        public static List<T> EmptyList<T>()
        {
            return EmptyEnumerable<T>().ToList();
        }

        public static E RandomElement<E>(this IList<E> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static E RandomElement<E>(params E[] values)
        {
            return values[UnityEngine.Random.Range(0, values.Length)];
        }

        public static E RandomElement<E>(this IList<E> list, Random random)
        {
            return list[random.Next(list.Count)];
        }

        public static E FirstOrAdd<E>(this IList<E> list, Func<E, bool> selector, Func<E> creator)
        {
            var f = list.FirstOrDefault(selector);
            if (f != null)
            {
                return f;
            }

            f = creator();
            list.Add(f);

            return f;
        }

        public static E FirstOrAdd<E>(this IList<E> list, Func<E, bool> selector) where E : new()
        {
            var f = list.FirstOrDefault(selector);
            if (f != null)
            {
                return f;
            }

            f = new E();
            list.Add(f);

            return f;
        }

        public static E CreateAndAdd<E>(this IList<E> list, Func<E> creator)
        {
            var e = creator();
            list.Add(e);
            return e;
        }

        public static E CreateAndAdd<E>(this IList<E> list) where E : new()
        {
            var e = new E();
            list.Add(e);
            return e;
        }

        public static E FirstOrDefaultComparable<E, T>(this IEnumerable<E> list, T comparable)
            where E : IComparable<T>
        {
            return list.FirstOrDefault(e => e.CompareTo(comparable) == 0);
        }

        public static List<T> CompositeList<T>(IEnumerable<IEnumerable<T>> enumerables)
        {
            var list = new List<T>();
            foreach (var enumerable in enumerables)
            {
                list.AddRange(enumerable);
            }

            return list;
        }

        /// <summary>
        /// Get all elements that are specified in func
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<T> FindAll<T>(this IEnumerable<T> enumerable, System.Func<T, bool> func)
        {
            var list = new List<T>();
            foreach (var element in enumerable)
                if (func(element))
                    list.Add(element);
            return list;
        }

        /// <summary>
        /// Remove all elements that attends func and return all elements that were removed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<T> RemoveAll<T>(this IList<T> list, System.Func<T, bool> func)
        {
            var removed = new List<T>();
            int count = list.Count;
            for (int i = count - 1; i > -1; i--)
            {
                var element = list[i];
                if (!func(element))
                    continue;
                list.RemoveAt(i);
                removed.Add(element);
            }
            return removed;
        }

        public static void AddRange<T>(this IList<T> list, IEnumerable<T> elements)
        {
            foreach (var element in elements)
                list.Add(element);
        }

        public static void AddRange<T>(this IList<T> list,params T[] param)
        {
            foreach (var element in param)
                list.Add(element);
        }

        /// <summary>
        /// Add a value only if there is not equal in list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="param"></param>
        public static void AddUnique<T>(this IList<T> list, params T[] param)
        {
            foreach (var item in param)
                if (!list.Contains(item))
                    list.Add(item);
        }

        /// <summary>
        /// Add the defaultValue at specified amount
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="numberToAdd"></param>
        /// <param name="defaultValue"></param>
        public static void AddNumberCopy<T>(this IList<T> list, int numberToAdd, T defaultValue)
        {
            for (int i = 0; i < numberToAdd; i++)
                list.Add(defaultValue);
        }

        /// <summary>
        /// Try get an element inside enumerable. If doesn't exist, will return default value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T TryGet<T>(this IEnumerable<T> enumerable, System.Func<T, bool> func)
        {
            foreach (var vari in enumerable)
                if (func(vari))
                    return vari;
            return default;
        }
    }
}