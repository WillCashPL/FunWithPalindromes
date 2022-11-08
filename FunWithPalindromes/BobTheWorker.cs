using PalindromesLib.Core;
using PalindromesLib.Models;

namespace FunWithPalindromes;

public class BobTheWorker
{
    private readonly PalindromeCheckCoordinator _palindromeCheckCoordinator;

    public BobTheWorker(PalindromeCheckCoordinator palindromeCheckCoordinator)
    {
        _palindromeCheckCoordinator = palindromeCheckCoordinator;
    }
    public void RunProgram()
    {
        var appShouldRun = true;
        while (appShouldRun)
        {
            try
            {
                Console.WriteLine("Please provide text to check for palindromes. (Empty line ends the program)");
                var textInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(textInput))
                {
                    appShouldRun = false;
                }
                else
                {
                    Console.WriteLine();
                    var result = _palindromeCheckCoordinator.GetPalindromesFromText(textInput).Take(3).ToList();
                    DisplayResults(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was some unexpected error. Exception details here:{e.Message}");
                break;
            }
            
        }
        
    }

    private void DisplayResults(List<TextWithExtendedInfo> resultList)
    {
        if (!resultList.Any())
        {
            Console.WriteLine("There are no results for the input given.");
            return;
        }
        
        foreach (var result in resultList)
        {
            Console.WriteLine(result.ToString());
        }
    }
}