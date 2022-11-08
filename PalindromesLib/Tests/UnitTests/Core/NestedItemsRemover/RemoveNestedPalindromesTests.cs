using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PalindromesLib.Models;
using Xunit;

namespace PalindromesLib.Tests.UnitTests.Core.NestedItemsRemover;

public class RemoveNestedPalindromesTests
{
    private readonly PalindromesLib.Core.NestedItemsRemover _nestedItemsRemover;
    public RemoveNestedPalindromesTests()
    {
        var mockedLogger = new Mock<ILogger>().Object;
        _nestedItemsRemover = new PalindromesLib.Core.NestedItemsRemover(mockedLogger);
    }

    [Theory]
    [ClassData(typeof(NestedItemsRemoverTestData))]
    public void ShouldReturnExpectedResult(List<TextWithExtendedInfo> inputList,
        List<TextWithExtendedInfo> expectedListOfResults)
    {
        var result = _nestedItemsRemover.RemoveNestedPalindromes(inputList);
        
        result.Should().BeEquivalentTo(expectedListOfResults,
            options => options
                .Including(x => x.Text)
                .Including(x => x.Length)
                .Including(x => x.OriginalIndex) 
        );
    }
}