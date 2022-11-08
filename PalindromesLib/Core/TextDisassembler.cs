using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using PalindromesLib.Interfaces;
using PalindromesLib.Models;

namespace PalindromesLib.Core;

public class TextDisassembler : ITextDisassembler
{
    private readonly ILogger _logger;
    public Regex NotReadableSingsRegex => new("[^a-zA-Z0-9]");

    public TextDisassembler(ILogger logger)
    {
        _logger = logger;
    }

    public IEnumerable<TextWithExtendedInfo> PrepareListOfStringsToCheck(string textToCheck)
    {
        var length = textToCheck.Length;
        var resultList = new List<TextWithExtendedInfo>();
        
        for (int i = length; i > 0; i--)
        {
            for (int j = 0; j <= length - i; j++)
            {
                try
                {
                    var substring = textToCheck.Substring(j, i);
                    if (!CheckFirstSignIsReadable(substring))
                        continue;
                    
                    var textInfo = new TextWithExtendedInfo(substring, j);
                    resultList.Add(textInfo);
                }
                catch (Exception e)
                {
                    _logger.LogError("An error occured during extracting a substring from text: {TextToCheck} -using start index: {J} and length: {I} The original error message: {Message}", textToCheck, j, i, e.Message);
                }
                
            }
        }
        return resultList;
    }
    
    public string CleanAllNonReadableSignsFromText(string textToBeCleaned)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(textToBeCleaned))
                return string.Empty;
            var regex = NotReadableSingsRegex;
            return regex.Replace(textToBeCleaned, "").ToLowerInvariant();
        }
        catch (Exception e)
        {
            _logger.LogError("An error occured during cleaning all non readable signs from text: {TextToBeCleaned} . The original error message: {Message}", textToBeCleaned, e.Message);
            return string.Empty;
        }
        
    }
    
    public bool CheckFirstSignIsReadable(string textToCheck)
    {
        if (string.IsNullOrWhiteSpace(textToCheck))
            return false;

        try
        {
            return !NotReadableSingsRegex.IsMatch(textToCheck.Substring(0,1));
        }
        catch (Exception e)
        {
            _logger.LogError("An error occured during checking if a first sign of a string: {TextToCheck} is readable. The original error message: {Message}", textToCheck, e.Message);
            return false;
        }
        
    }
}