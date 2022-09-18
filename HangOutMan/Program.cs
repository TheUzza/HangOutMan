using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace HangOutmanAppTest
{
    internal class Program
    {
        private static void printHangOutman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
            }
            else if (wrong == 1)
            {
                Console.WriteLine(" O  O |");
                Console.WriteLine("/|\\   |");
                Console.WriteLine("/ \\   |");

            }
            else if (wrong == 2)
            {
                Console.WriteLine(" O  O |");
                Console.WriteLine("/|\\/|\\|");
                Console.WriteLine("/ \\   |");

            }
            else if (wrong == 3)
            {
                Console.WriteLine(" O  O   |");
                Console.WriteLine("/|\\/|\\  |");
                Console.WriteLine("/ \\/ \\  |");

            }
            else if (wrong == 4)
            {
                Console.WriteLine(" O  O  O |");
                Console.WriteLine("/|\\/|\\   |");
                Console.WriteLine("/ \\/ \\   |");
            }
            else if (wrong == 5)
            {
                Console.WriteLine(" O  O  O |");
                Console.WriteLine("/|\\/|\\/|\\|");
                Console.WriteLine("/ \\/ \\   |");
            }
            else if (wrong == 6)
            {
                Console.WriteLine(" O  O  O   |");
                Console.WriteLine("/|\\/|\\/|\\  |");
                Console.WriteLine("/ \\/ \\/ \\  |");
            }
        }

        private static int printWord(List<char> guessed, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessed.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write("  ");
                }
                counter += 1;
            }
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Help HangoutMan avoid hanging out with his friends who can reassemble themselves");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "knight", "dungeon", "dragon", "kingdom", "mountain", "france", "horse", "king", "queen" };
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                Console.Write("\nGuess a letter: ");
                char guessed = Console.ReadLine()[0];
                if (currentLettersGuessed.Contains(guessed))
                {
                    Console.Write("\r\n You have already guessed that");
                    printHangOutman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) { if (guessed == randomWord[i]) { right = true; } }

                    if (right)
                    {
                        printHangOutman(amountOfTimesWrong);
                        // Print word
                        currentLettersGuessed.Add(guessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    // User was wrong af
                    else
                    {
                        amountOfTimesWrong += 1;
                        currentLettersGuessed.Add(guessed);
                        printHangOutman(amountOfTimesWrong);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame is over!");
        }
    }
}
