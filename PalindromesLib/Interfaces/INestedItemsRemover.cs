using PalindromesLib.Models;

namespace PalindromesLib.Core;

public interface INestedItemsRemover
{
    IEnumerable<TextWithExtendedInfo> RemoveNestedPalindromes(List<TextWithExtendedInfo> listToCheck);
}