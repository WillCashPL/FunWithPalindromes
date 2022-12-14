using Microsoft.Extensions.Logging;
using Moq;
using PalindromesLib.Core;
using Xunit;

namespace PalindromesLib.Tests.UnitTests.Core.PalindromeChecker;

public class CheckIsPalindromeTests
{
    private readonly PalindromesChecker _palindromesChecker;
    public CheckIsPalindromeTests()
    {
        var mockedLogger = new Mock<ILogger>().Object;
        _palindromesChecker = new PalindromesChecker(mockedLogger);
    }
    
    [Theory]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("aba")]
    [InlineData("aaaaddaaaa")]
    [InlineData("aaaadaaaa")]
    [InlineData("hijkllkjih")]
    [InlineData("defggfed")]
    [InlineData("abccba")]
    public void ReturnsTrueWhenInputIsPalindrome(string lowerCaseOnlyReadableSignsTextToCheck)
    {
        var result = _palindromesChecker.CheckIsPalindrome(lowerCaseOnlyReadableSignsTextToCheck);
        Assert.True(result);
    }
    [Theory]
    [InlineData("")]
    [InlineData("ab")]
    [InlineData("aab")]
    [InlineData("abab")]
    [InlineData("aaaaddaaaas")]
    [InlineData("daaaadaaaa")]
    [InlineData("hijklijlkjih")]
    [InlineData("defg12gfed")]
    [InlineData("absccdba")]
    public void ReturnsFalseWhenInputIsNotPalindrome(string lowerCaseOnlyReadableSignsTextToCheck)
    {
        var result = _palindromesChecker.CheckIsPalindrome(lowerCaseOnlyReadableSignsTextToCheck);
        Assert.False(result);
    }
}