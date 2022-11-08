using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PalindromesLib.Models;
using Xunit;

namespace PalindromesLib.Tests.UnitTests.Core.TextDisassembler;

public class PrepareListOfStringsToCheckTests
{
    private readonly PalindromesLib.Core.TextDisassembler _textDisassembler;

    public PrepareListOfStringsToCheckTests()
    {
        var mockedLogger = new Mock<ILogger>().Object;
        _textDisassembler = new PalindromesLib.Core.TextDisassembler(mockedLogger);
    }
    
    [Theory]
    [ClassData(typeof(TextDisassemblerTestData))]
    public void ReturnsExpectedListOfResults(string text, List<TextWithExtendedInfo> expectedListOfResults)
    {
        var result = _textDisassembler.PrepareListOfStringsToCheck(text).ToList();


        result.Should().BeEquivalentTo(expectedListOfResults,
            options => options
                .Including(x => x.Text)
                .Including(x => x.Length)
                .Including(x => x.OriginalIndex) 
            );

    }
}