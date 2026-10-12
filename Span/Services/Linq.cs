using Common.Services;

namespace Span;

public static class Linq
{
    public static IEnumerable<NotebookUser> WhereWithSpan(this IEnumerable<NotebookUser> users, Func<NotebookUser, bool> predicate)
    {
        var data = users as NotebookUser[] ?? users.ToArray();
        ReadOnlySpan<NotebookUser> span = data.AsSpan();

        var result = new NotebookUser[span.Length];
        for (int i = 0; i < span.Length; i++)
            if (predicate(span[i]))
                result[i] = span[i];

        if (result.Length is 0)
            return null!;

        return result;
    }

    public static IEnumerable<NotebookUser> WhereWithList(this IEnumerable<NotebookUser> users, Func<NotebookUser, bool> predicate)
    {
        var result = new List<NotebookUser>();
        var userArray = users.ToArray();
        for (int i = 0; i < userArray.Count(); i++)
        {
            var user = userArray[i];
            if (predicate(user))
                result.Add(user);
        }

        if (result.Count is 0)
            return null!;

        return result;
    }
}
