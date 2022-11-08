using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using Moq;
using PalindromesLib.Core;

namespace BenchmarkTests.Core;

[MemoryDiagnoser()]
public class NestedItemsRemoverBenchmarks
{
    private NestedItemsRemover _nestedItemsRemover;

    public NestedItemsRemoverBenchmarks()
    {
        var mockedLogger = new Mock<ILogger>().Object;
        _nestedItemsRemover = new NestedItemsRemover(mockedLogger);
    }
}