using BenchmarkDotNet.Attributes;

namespace Common.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class NotebookBenchmarkAttribute : BenchmarkAttribute
{
}
