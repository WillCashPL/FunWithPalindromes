using PalindromesLib.Models;

namespace PalindromesLib.Interfaces;

public interface ITextDisassembler
{
    IEnumerable<TextWithExtendedInfo> PrepareListOfStringsToCheck(string textToCheck);
    string CleanAllNonReadableSignsFromText(string textToBeCleaned);
}