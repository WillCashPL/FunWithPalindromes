# Table of Contents
1. [What the app does?](#what-the-app-does)
2. [Building the app](#building-the-app)
3. [Running the app](#running-the-app)
4. [How to use the app](#how-to-use-the-app)
5. [Assumptions made during coding the app](#assumptions-made-during-coding-the-app)


## What the app does?
This is a console app. It checks within the provided text for palindromes. Then it shows 3 longest palindromes (with the information about starting point and the length of the palindrome).

## Building The App
In order to build app, open terminal/command in the FunWithPalindromes main directory
and run the command: `dotnet build`. The app requires .Net 6 SDK to be installed on the system. 
If it is not installed, please follow the [link to download the package](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) and then install it.
## Running the app
In order to run app, open terminal/command in the FunWithPalindromes main directory, go to the FunWithPalindromes subfolder (you can use command `cd FunWithPalindromes` to do that) 
and then run a command: `dotnet run`
## How to use the app
This application is a [Command Line Interface (CLI) ](https://en.wikipedia.org/wiki/Command-line_interface)tool. 
In order to use it, please follow the instructions that will appear in the console window.

## Assumptions made during coding the app

The definition of the palindrome: (from [Wiki](https://en.wikipedia.org/wiki/Palindrome)):

_A palindrome is a word, number, phrase, or other sequence of symbols that reads the same backwards as forwards, such the words madam or racecar, the date/time stamps 11/11/11 11:11 and 02/02/2020, and the sentence: "A man, a plan, a canal – Panama"._

Based on that definition, I've made a few assumptions:
1. We use signs that can be read. This means we shouldn't take into consideration any unreadable signs, such as space, "/", "-", ",", ".", " " etc. Those should be ignored. Ultimately, I used regex `Regex("[^a-zA-Z0-9]")` to filter out all non necessary symbols.
2. Palindromes could be multi-word sentences (this is indicated in the statement above, but I want to make it super clear). We don't care about spaces and other white signs.
3. Palindromes are case insensitive. This means that `abba` is a palindrome as well as `Abba`, `ABba` and `aBba`.
4. Palindromes can be written using other symbols than used in latin alphabet (such as greek, 4-th century palindrome: `ΝΙΨΟΝ ΑΝΟΜΗΜΑΤΑ ΜΗ ΜΟΝΑΝ ΟΨΙΝ` (translation: "Wash your sins, not only face")). They can appear also outside the "written world", e.g. in biology we have palindromic butterflies, in music we can have palindromic phrases (The interlude from Alban Berg's opera Lulu) and others. This program will cover only palindromes written using signs from latin alphabet and digits.
5. This program won't check if a palindrome is a real word/sentence or not.
6. This program won't check if a sentence built from signs that can be read, is readable itself.

A few other assumptions and thoughts:
1. What's the length of a palindrome? I assume it is the length of all readable signs in the palindrome. So, based on that assumption, those two palindromes will have the same length: `20022002` and `20-02-2002`.
2. Same problem with the starting index. If we'll get this text: `!-abccba`, I assume that the starting index should be `2`, because that's the point where the first readable symbol (`a`) is located.
3. When are palindromes different? Well, my assumption (which is consistent with what I wrote above) is that palindromes are different if they are built from different readable signs or from the same signs (regardless of the case of letters) that are put in a different order. So, those palindromes will be considered the same: `ab-cba`,`ab-cb/a`,`aBcba` and `abcb;;A`.
4. There are few ways to check if a word is palindrome or not. Some of them are faster than others. I decided to use the easiest to understand method. (well, in my opinion of course :) ). Thanks to that, the solution is easier to maintain. Since I used Dependency Injection, it is possible to write a new method and it is very easy to swap it with the current one. I added few other methods as well and benchmarked them. But, when you'll run the program, the easiest to understand method will be used. 
5. I gave a couple of thoughts to the question: Should I create a multi-threaded app? But I decided to keep it simple and use only a single thread here.
6. The program won't show nested palindromes (e.g. in `hijkllkjih` there are few nested palindromes such as `ijkllkji` and `jkllkj` and so on).
7. Last one - this is something that troubles me from the very beginning of this project - should I treat a single letter as a palindrome? Should I consider letter to be a word or a phrase? Google says `yes Łukasz, you should consider them as words`. Ok, so be it. But what about digits? Let's assume that all one-symbol phrases are palindromes.
