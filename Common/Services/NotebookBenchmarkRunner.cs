using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using Perfolizer.Horology;
using Perfolizer.Metrology;
using System.Collections.Immutable;
using System.Globalization;

namespace Common.Services;

public static class NotebookBenchmarkRunner
{
    public static Summary Run<T>(IConfig? config = null, string[]? args = null)
    {
        return BenchmarkRunner.Run<T>(config, args);
    }
}

//public class NotebookSummary : Summary
//{
//    public NotebookSummary(string title,
//                           ImmutableArray<BenchmarkReport> reports,
//                           HostEnvironmentInfo hostEnvironmentInfo,
//                           string resultsDirectoryPath,
//                           string logFilePath,
//                           TimeSpan totalTime,
//                           CultureInfo cultureInfo,
//                           ImmutableArray<ValidationError> validationErrors,
//                           ImmutableArray<IColumnHidingRule> columnHidingRules,
//                           SummaryStyle? summaryStyle = null) : base(title,
//                                                                     reports,
//                                                                     hostEnvironmentInfo,
//                                                                     resultsDirectoryPath,
//                                                                     logFilePath,
//                                                                     totalTime,
//                                                                     cultureInfo,
//                                                                     validationErrors,
//                                                                     columnHidingRules,
//                                                                     summaryStyle)
//    {
//    }
//}