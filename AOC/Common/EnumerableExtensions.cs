namespace AOC.Common;

public static class EnumerableExtensions
{
    public static IEnumerable<T> SkipElementAt<T>(this IEnumerable<T> source, int index)
    {
        var count = 0;

        foreach (var item in source)
        {
            if (count != index)
            {
                yield return item;
            }

            count++;
        }
    }

    public static IEnumerable<(T left, T right)> Pairwise<T>(this IEnumerable<T> source)
    {
        return source.Pairwise((l, r) => (l, r));
    }

    public static IEnumerable<TResult> Pairwise<T, TResult>(
        this IEnumerable<T> source,
        Func<T, T, TResult> selector)
    {
        var previous = default(T);
        var hasValue = false;
        foreach (var item in source)
        {
            if (hasValue && previous is not null)
            {
                yield return selector(previous, item);
            }

            previous = item;
            hasValue = true;
        }
    }
}