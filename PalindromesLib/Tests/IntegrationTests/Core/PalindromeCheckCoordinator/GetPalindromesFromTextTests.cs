using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PalindromesLib.Core;
using PalindromesLib.Models;
using Xunit;

namespace PalindromesLib.Tests.IntegrationTests.Core.PalindromeCheckCoordinator;

public class GetPalindromesFromTextTests
{
    private readonly PalindromesLib.Core.PalindromeCheckCoordinator _palindromeCheckCoordinator;

    public GetPalindromesFromTextTests()
    {
        var mockedLogger = new Mock<ILogger>().Object;
        var palindromeChecker = new PalindromesChecker(mockedLogger);
        var textDisassembler = new TextDisassembler(mockedLogger);
        var nestedItemsRemover = new NestedItemsRemover(mockedLogger);

        _palindromeCheckCoordinator =
            new PalindromesLib.Core.PalindromeCheckCoordinator(palindromeChecker, textDisassembler, nestedItemsRemover, mockedLogger);
    }

    [Theory]
    [ClassData(typeof(PalindromeCheckCoordinatorTestData))]
    public void ReturnsExpectedListOfResultsForTop10Elements(string text, List<TextWithExtendedInfo> expectedListOfResults)
    {
        var result = _palindromeCheckCoordinator.GetPalindromesFromText(text).ToList();

        result.Take(10).Should().BeEquivalentTo(expectedListOfResults,
            options => options
                .Including(x => x.Text)
                .Including(x => x.Length)
                .Including(x => x.OriginalIndex)
        );
    }

    [Theory]
    [ClassData(typeof(PalindromeCheckCoordinatorTestData))]
    public void ReturnsListSortedByLongestPalindrome(string text, List<TextWithExtendedInfo> _)
    {
        var result = _palindromeCheckCoordinator.GetPalindromesFromText(text).ToList();

        result.Should().BeInDescendingOrder(x => x.Length);

    }
    
    [Theory]
    [ClassData(typeof(PalindromeCheckCoordinatorTestData))]
    public void ReturnsListWithUniqueStrings(string text, List<TextWithExtendedInfo> _)
    {
        var result = _palindromeCheckCoordinator.GetPalindromesFromText(text).ToList();

        result.Should().OnlyHaveUniqueItems(x => x.Text);

    }
}