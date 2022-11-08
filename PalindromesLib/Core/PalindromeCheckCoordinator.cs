using Microsoft.Extensions.Logging;
using PalindromesLib.Interfaces;
using PalindromesLib.Models;

namespace PalindromesLib.Core;

public class PalindromeCheckCoordinator
{
    private readonly IPalindromesChecker _palindromesChecker;
    private readonly ITextDisassembler _textDisassembler;
    private readonly INestedItemsRemover _nestedItemsRemover;
    private readonly ILogger _logger;

    public PalindromeCheckCoordinator(IPalindromesChecker palindromesChecker, ITextDisassembler textDisassembler,
        INestedItemsRemover nestedItemsRemover, ILogger logger)
    {
        _palindromesChecker = palindromesChecker;
        _textDisassembler = textDisassembler;
        _logger = logger;
        _nestedItemsRemover = nestedItemsRemover;
    }

    public IEnumerable<TextWithExtendedInfo> GetPalindromesFromText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Enumerable.Empty<TextWithExtendedInfo>();
        try
        {
            var listToCheck = _textDisassembler.PrepareListOfStringsToCheck(text).ToList();
            if (!listToCheck.Any())
                return Enumerable.Empty<TextWithExtendedInfo>();

            var listOfDistinctPalindromes = GetListOfDistinctPalindromes(listToCheck).ToList();
            if (!listOfDistinctPalindromes.Any())
                return Enumerable.Empty<TextWithExtendedInfo>();

            return listOfDistinctPalindromes;
        }
        catch (Exception e)
        {
            _logger.LogError(
                "A general error occured during extracting palindromes from a text. The original error message: {Message}",
                e.Message);
            return Enumerable.Empty<TextWithExtendedInfo>();
        }
    }

    public IEnumerable<TextWithExtendedInfo> GetListOfDistinctPalindromes(List<TextWithExtendedInfo> listToCheck)
    {
        if (!listToCheck.Any())
            return Enumerable.Empty<TextWithExtendedInfo>();
        try
        {
            var resultList = listToCheck
                .Select(x =>
                    new TextWithExtendedInfo(_textDisassembler.CleanAllNonReadableSignsFromText(x.Text),
                        x.OriginalIndex))
                .OrderByDescending(x => x.Length).ThenBy(x => x.OriginalIndex)
                .Distinct(TextWithExtendedInfo.TextOriginalIndexComparer)
                .Where(x => _palindromesChecker.CheckIsPalindrome(x.Text))
                .ToList();
            
            return _nestedItemsRemover.RemoveNestedPalindromes(resultList).ToList();
        }
        catch (Exception e)
        {
            _logger.LogError(
                "An error occured during preparing a list of distinct palindromes. The original error message: {Message}",
                e.Message);
            return Enumerable.Empty<TextWithExtendedInfo>();
        }
    }

    
}