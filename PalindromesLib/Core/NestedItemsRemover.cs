using Microsoft.Extensions.Logging;
using PalindromesLib.Models;

namespace PalindromesLib.Core;

public class NestedItemsRemover : INestedItemsRemover
{
    private readonly ILogger _logger;

    public NestedItemsRemover(ILogger logger)
    {
        _logger = logger;
    }

    public IEnumerable<TextWithExtendedInfo> RemoveNestedPalindromes(List<TextWithExtendedInfo> listToCheck)
    {
        if (!listToCheck.Any())
            return Enumerable.Empty<TextWithExtendedInfo>();

        var result = new List<TextWithExtendedInfo>(listToCheck);
        try
        {
            foreach (var palindrome in listToCheck)
            {
                result.RemoveAll(x =>
                    x.OriginalIndex >= palindrome.OriginalIndex && x.OriginalIndex <= palindrome.OriginalIndex + palindrome.Length 
                    && x.OriginalIndex + x.Length >= palindrome.OriginalIndex && x.OriginalIndex + x.Length <= palindrome.OriginalIndex + palindrome.Length
                    && x.Length < palindrome.Length
                    );
            }

            return result.ToList();
        }
        catch (Exception e)
        {
            _logger.LogError(
                "An error occured during removing nested palindromes. The original error message: {Message}",
                e.Message);
            return Enumerable.Empty<TextWithExtendedInfo>();
        }
    }
}