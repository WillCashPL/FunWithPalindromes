using System.Configuration;
using Microsoft.Extensions.Logging;
using PalindromesLib.Interfaces;

namespace PalindromesLib.Core;

public class PalindromesChecker : IPalindromesChecker
{
    private readonly ILogger _logger;

    public PalindromesChecker(ILogger logger)
    {
        _logger = logger;
    }

    public bool CheckIsPalindrome(string lowerCaseOnlyReadableSignsTextToCheck)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(lowerCaseOnlyReadableSignsTextToCheck))
                return false;
            return lowerCaseOnlyReadableSignsTextToCheck.SequenceEqual(lowerCaseOnlyReadableSignsTextToCheck.Reverse());
        }
        catch (Exception e)
        {
            _logger.LogError(
                "An error occured during checking if the string: {TextToCheck} is a palindrome. The original error message: {Message}",
                lowerCaseOnlyReadableSignsTextToCheck, e.Message);
            return false;
        }
    }

    public bool CheckIsPalindromeWithArrays(string lowerCaseOnlyReadableSignsTextToCheck)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(lowerCaseOnlyReadableSignsTextToCheck))
                return false;
            
            string first =
                lowerCaseOnlyReadableSignsTextToCheck.Substring(0, lowerCaseOnlyReadableSignsTextToCheck.Length / 2);
            char[] arr = lowerCaseOnlyReadableSignsTextToCheck.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            string second = temp.Substring(0, temp.Length / 2);

            return first.Equals(second);
        }
        catch (Exception e)
        {
            _logger.LogError(
                "An error occured during checking if the string: {TextToCheck} is a palindrome. The original error message: {Message}",
                lowerCaseOnlyReadableSignsTextToCheck, e.Message);
            return false;
        }
    }
    
    public bool CheckIsPalindromeWithSpans(ReadOnlySpan<char> lowerCaseOnlyReadableSignsTextToCheck)
    {
        try
        {
            if (lowerCaseOnlyReadableSignsTextToCheck.IsEmpty)
                return false;

            var firstPartSlice = lowerCaseOnlyReadableSignsTextToCheck.Slice(0,
                lowerCaseOnlyReadableSignsTextToCheck.Length / 2);
            
            
            Span<char> reverse = new Span<char>(GC.AllocateUninitializedArray<char>(lowerCaseOnlyReadableSignsTextToCheck.Length));

            for (int i = 0; i < lowerCaseOnlyReadableSignsTextToCheck.Length; i++)
            {
                reverse[i] = lowerCaseOnlyReadableSignsTextToCheck[lowerCaseOnlyReadableSignsTextToCheck.Length -1 - i];
            }
            
            var secondPartSlice = reverse.Slice(0, reverse.Length / 2);

            var result = true;
            if (firstPartSlice.Length == secondPartSlice.Length)
            {
                for (int i = 0; i < firstPartSlice.Length; i++)
                {
                    result = result && firstPartSlice[i] == secondPartSlice[i];
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(
                "An error occured during checking if the string: {TextToCheck} is a palindrome. The original error message: {Message}",
                lowerCaseOnlyReadableSignsTextToCheck.ToString(), e.Message);
            return false;
        }
    }
    
    public bool CheckIsPalindromeWithSpansV2(ReadOnlySpan<char> lowerCaseOnlyReadableSignsTextToCheck)
    {
        try
        {
            if (lowerCaseOnlyReadableSignsTextToCheck.IsEmpty)
                return false;


            Span<char> reverse = new Span<char>(GC.AllocateUninitializedArray<char>(lowerCaseOnlyReadableSignsTextToCheck.Length));

            for (int i = 0; i < lowerCaseOnlyReadableSignsTextToCheck.Length; i++)
            {
                reverse[i] = lowerCaseOnlyReadableSignsTextToCheck[lowerCaseOnlyReadableSignsTextToCheck.Length -1 - i];
            }

            var result = true;
            if (lowerCaseOnlyReadableSignsTextToCheck.Length == reverse.Length)
            {
                for (int i = 0; i < lowerCaseOnlyReadableSignsTextToCheck.Length; i++)
                {
                    result = result && lowerCaseOnlyReadableSignsTextToCheck[i] == reverse[i];
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(
                "An error occured during checking if the string: {TextToCheck} is a palindrome. The original error message: {Message}",
                lowerCaseOnlyReadableSignsTextToCheck.ToString(), e.Message);
            return false;
        }
    }
}