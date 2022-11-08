using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace PalindromesLib.Tests.UnitTests.Core.TextDisassembler;

public class CleanAllNonReadableSignsFromTextTests
{
    private readonly PalindromesLib.Core.TextDisassembler _textDisassembler;

    public CleanAllNonReadableSignsFromTextTests()
    {
        var mockedLogger = new Mock<ILogger>().Object;
        _textDisassembler = new PalindromesLib.Core.TextDisassembler(mockedLogger);
    }

    [Theory]
    [InlineData("a", "a")]
    [InlineData("_ab*c", "abc")]
    [InlineData("_ab*crew123", "abcrew123")]
    [InlineData("_ab*cASD234__fd", "abcasd234fd")]
    public void ShouldReturnExpectedResult(string text, string expectedResult)
    {
        var result = _textDisassembler.CleanAllNonReadableSignsFromText(text);
        
        Assert.Equal(expectedResult,result);
    }
}