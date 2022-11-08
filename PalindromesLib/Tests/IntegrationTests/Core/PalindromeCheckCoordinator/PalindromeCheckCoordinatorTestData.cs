using System.Collections;
using PalindromesLib.Models;

namespace PalindromesLib.Tests.IntegrationTests.Core.PalindromeCheckCoordinator;

public class PalindromeCheckCoordinatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "abc", new List<TextWithExtendedInfo>
            {
                new("a", 0),
                new("b", 1),
                new("c", 2),
            }
        };
        yield return new object[]
        {
            "_abc", new List<TextWithExtendedInfo>
            {
                new("a", 1),
                new("b", 2),
                new("c", 3),
            }
        };
        yield return new object[]
        {
            "_ab*c", new List<TextWithExtendedInfo>
            {
                new("a", 1),
                new("b", 2),
                new("c", 4),
            }
        };
        yield return new object[]
        {
            "_ab*ba", new List<TextWithExtendedInfo>
            {
                new("abba", 1),
            }
        };
        yield return new object[]
        {
            "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop", new List<TextWithExtendedInfo>
            {
                new("hijkllkjih", 23),
                new("defggfed", 13),
                new("abccba", 5),
                new("qrrq", 1),
                new("mnnm", 35),
                new("pop", 40),
                new("s", 0),
                new("t", 11),
                new("u", 12),
                new("v", 21),
            }
        };
        yield return new object[]
        {
            "aaaaabbaa", new List<TextWithExtendedInfo>
            {
                new("aabbaa", 3),
                new("aaaaa", 0),
            }
        };
        yield return new object[]
        {
            "20/02/2002", new List<TextWithExtendedInfo>
            {
                new("20022002", 0),
            }
        };
        yield return new object[]
        {
            "ΝΙΨΟΝ ΑΝΟΜΗΜΑΤΑ ΜΗ ΜΟΝΑΝ ΟΨΙΝ", new List<TextWithExtendedInfo>()
        };
        yield return new object[]
        {
            "!-abccba", new List<TextWithExtendedInfo>
            {
                new("abccba", 2),
            }
        };
        yield return new object[]
        {
            "abcb;;A_ab-cba_ab-cb/a_abcb;;A", new List<TextWithExtendedInfo>
            {
                new("abcbaabcbaabcbaabcba", 0),
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() =>  GetEnumerator();
}
