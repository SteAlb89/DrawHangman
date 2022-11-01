using System;
using System.Collections.Generic;

namespace HangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int lives = 6;
            Console.WriteLine("Welcome To Hangman Game!");
            Console.WriteLine($"Hint: You have {lives} lives");
            Console.WriteLine("------------------------------------------------------");
            List<string> wordList = new List<string>() { "excavator", "celullar", "microphone", "building","bussiness", "flower","morning","summer",
                "butterfly","meditation","programming","shower","negative","abundance","beautifull","message"};
            Random rnd = new Random();
            int index = rnd.Next(wordList.Count);

            string hiddenWord = wordList[index];
            List<char> stars = new List<char>();
            List<string[]> hangmanPics = new List<string[]>
            { new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "       |\n",
                    "       |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    "       |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    "  |    |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    " /|    |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    " /|\\   |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    " /|\\   |\n",
                    " /     |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    " /|\\   |\n",
                    " / \\   |\n",
                    "       |\n",
                    "=========\n"
                },
            };
            foreach (char letter in hiddenWord)
            {
                stars.Add('*');
            }

            int attempts = 0;
            while (true)
            {
                Console.WriteLine("Today the word is: " + String.Join("", stars));

                Console.Write("Guess a letter: ");
                char guessedLetter = char.Parse(Console.ReadLine());

                bool guessedCorrectLetter = false;
                for (int i = 0; i < hiddenWord.Length; i++)
                {
                    if (guessedLetter == hiddenWord[i])
                    {
                        stars[i] = guessedLetter;
                        guessedCorrectLetter = true;
                    }
                }
                if (guessedCorrectLetter)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You guessed the letter");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"This letter doesn't belong to the word ");
                    Console.ResetColor();
                    lives--;
                    Console.Clear();
                    foreach(var pic in hangmanPics[0])
                    {
                        Console.WriteLine(pic);
                    }
                    hangmanPics.RemoveAt(0);
                    
                }
                attempts++;
                Console.WriteLine($"You tried {attempts} times");

                if (!stars.Contains('*'))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulation, you guessed!");
                    Console.ResetColor();
                    Console.WriteLine($"The word was --- {hiddenWord} ---");
                    break;
                }
            }
        }
    }
}
