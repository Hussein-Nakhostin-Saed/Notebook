using Common.Attributes;
using Common.Services;

namespace Span.Benchmark;

[NotebookMemoryDiagnoser]
public class LinqComparer
{
    private IEnumerable<NotebookUser> _items;

    [NotebookGlobalSetup]
    public void SetUp()
    {
        NotebookFaker.SetSeed(42);
        _items = NotebookFaker.GenerateUsers(100000);
    }

    [NotebookBenchmark]
    public void WhereOnSpan()
    {
        _items.WhereWithSpan(x => x.DateOfBirth > DateTime.Now.AddYears(-30));
    }

    [NotebookBenchmark]
    public void WhereOnList()
    {
        _items.WhereWithList(x => x.DateOfBirth > DateTime.Now.AddYears(-30));
    }
}
