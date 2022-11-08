using System.Collections;
using PalindromesLib.Models;

namespace PalindromesLib.Tests.UnitTests.Core.NestedItemsRemover;

public class NestedItemsRemoverTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new List<TextWithExtendedInfo>
            {
                new("abaaba", 0),
                new("baab", 1),
                new("aa", 3),
                new("a", 0),
                new("b", 1),
            }, new List<TextWithExtendedInfo>
            {
                new("abaaba", 0)
            }
        };
        yield return new object[]
        {
            new List<TextWithExtendedInfo>
            {
                new("hijkllkjih", 23),
                new("defggfed", 13),
                new("ijkllkji", 24),
                new("abccba", 5),
                new("efggfe", 14),
                new("jkllkj", 25),
                new("qrrq", 1),
                new("bccb", 6),
                new("fggf", 15),
                new("kllk", 26),
            },
            new List<TextWithExtendedInfo>
            {
                new("hijkllkjih", 23),
                new("defggfed", 13),
                new("abccba", 5),
                new("qrrq", 1),
            }
        };
        yield return new object[]
        {
            new List<TextWithExtendedInfo>
            {
                new("abaaaaba", 3),
                new("abaaba", 0),
                new("baab", 1),
                new("aa", 3),
                new("a", 0),
                new("b", 1),
            }, new List<TextWithExtendedInfo>
            {
                new("abaaaaba", 3),
                new("abaaba", 0)
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() =>  GetEnumerator();
}
