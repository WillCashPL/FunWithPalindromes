using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using Moq;
using PalindromesLib.Core;

namespace BenchmarkTests.Core;

[MemoryDiagnoser()]
public class PalindromesCheckerBenchmark
{

    private const string Palindrome = "aaaaabbbbbcccccbbbbbaaaaalasdkjh lsldfkjhladskfhlsdkfjhlsadfjhlasdkfjhlj lkjshflksjdhflksajhflasjfhljl";
    private static readonly PalindromesChecker PalindromesChecker = new PalindromesChecker(new Mock<ILogger>().Object);

    [Benchmark(Baseline = true)]
    public void CheckIsPalindrome()
    {
        PalindromesChecker.CheckIsPalindrome(Palindrome);
    }

    [Benchmark]
    public void CheckIsPalindromeWithArrays()
    {
        PalindromesChecker.CheckIsPalindromeWithArrays(Palindrome);
    }
    
    [Benchmark]
    public void CheckIsPalindromeWithSpans()
    {
        PalindromesChecker.CheckIsPalindromeWithSpans(Palindrome);
    }
    
    [Benchmark]
    public void CheckIsPalindromeWithSpansV2()
    {
        PalindromesChecker.CheckIsPalindromeWithSpansV2(Palindrome);
    }
}