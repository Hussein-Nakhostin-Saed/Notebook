using BenchmarkDotNet.Attributes;

namespace Common.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class NotebookMemoryDiagnoserAttribute : MemoryDiagnoserAttribute
{
}
