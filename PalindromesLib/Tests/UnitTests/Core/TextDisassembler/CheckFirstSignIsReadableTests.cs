using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace PalindromesLib.Tests.UnitTests.Core.TextDisassembler;

public class CheckFirstSignIsReadableTests
{
    private readonly PalindromesLib.Core.TextDisassembler _textDisassembler;

    public CheckFirstSignIsReadableTests()
    {
        var mockedLogger = new Mock<ILogger>().Object;
        _textDisassembler = new PalindromesLib.Core.TextDisassembler(mockedLogger);
    }

    [Theory]
    [InlineData("a", true)]
    [InlineData("abs", true)]
    [InlineData("Daa", true)]
    [InlineData("1_sa", true)]
    [InlineData("d[da", true)]
    [InlineData("D*1a", true)]
    [InlineData("_D*1a", false)]
    [InlineData(" D*1a", false)]
    [InlineData("**1a", false)]
    [InlineData("_1D*1a", false)]
    [InlineData("(d*1a", false)]
    public void ShouldReturnExpectedResult(string text, bool expectedResult)
    {
        var result = _textDisassembler.CheckFirstSignIsReadable(text);
        
        Assert.Equal(expectedResult,result);
    }
}