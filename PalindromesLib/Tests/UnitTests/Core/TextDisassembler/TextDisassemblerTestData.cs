using System.Collections;
using PalindromesLib.Models;

namespace PalindromesLib.Tests.UnitTests.Core.TextDisassembler;

public class TextDisassemblerTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "abc", new List<TextWithExtendedInfo>
            {
                new("abc", 0),
                new("ab", 0),
                new("bc", 1),
                new("a", 0),
                new("b", 1),
                new("c", 2),
            }
        };
        yield return new object[]
        {
            "_abc", new List<TextWithExtendedInfo>
            {
                new("abc", 1),
                new("ab", 1),
                new("bc", 2),
                new("a", 1),
                new("b", 2),
                new("c", 3),
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() =>  GetEnumerator();
}
