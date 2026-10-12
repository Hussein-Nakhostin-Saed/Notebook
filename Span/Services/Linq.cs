namespace Span;

public static class Linq
{
    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        return default!;
    }

    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
        return default!;
    }

    public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
        return default!;
    }
}
