using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HangmanStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Collection of words to guess
            string[] words = { "triangle", "circle", "rectangle", "square", "hexagon", "pentagon" };

            // Starts game with random word
            string randomWord = words[random.Next(0, words.Length)];
            Play(randomWord);

            Console.ReadLine();
        }

        static void Play(string word)
        {
            // SB for display to user
            StringBuilder display = new StringBuilder(word.Length);
            for (int i = 0; i < word.Length; i++)
                display.Append('_').Append(' ');

            // Array of unique letters in word to guess
            var lettersToGuess = word.Distinct().ToArray();

            // Stores guessed letters
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 10;
            bool won = false;

            // Initial display
            Console.WriteLine("Lives: {0}\n\nWord to guess: {1}", lives, display);

            while (!won && lives > 0)
            {
                Console.Write("Please enter a letter to guess: ");

                try
                {
                    char c = Convert.ToChar(Console.ReadLine());
                    Console.Clear();

                    if (lettersToGuess.Contains(c))
                    {
                        correctGuesses.Add(c);
                        // Removes correct guess from lettersToGuess
                        lettersToGuess = lettersToGuess.Where(lettersToGuess => lettersToGuess != c).ToArray();

                        if (lettersToGuess.Length == 0)
                        {
                            won = true;
                            AnimateWin();
                            Console.WriteLine("Congrats, you win! The word was {0}", word);
                            break;
                        }
                    }
                    else if (correctGuesses.Contains(c) || incorrectGuesses.Contains(c))
                    {
                        Console.WriteLine("You've already guessed '{0}'! Try again", c);
                    }
                    else
                    {
                        incorrectGuesses.Add(c);
                        lives--;
                    }

                    // Updates SB with correct guesses
                    display = new StringBuilder(word.Length);
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (correctGuesses.Contains(word.ToCharArray()[i]))
                        {
                            display.Append(word.ToCharArray()[i]).Append(' ');
                        }
                        else
                        {
                            display.Append('_').Append(' ');
                        }
                    }

                    // Draws body according to number of incorrect guesses
                    DrawBody(incorrectGuesses.Count);

                    // Updates display
                    Console.WriteLine("Lives: {0}\n\nWord to guess: {1}", lives, display);
                    Console.WriteLine("Incorrect guesses: {0}", new string(string.Join(",", incorrectGuesses)));
                    Console.Write("\n");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: {0}\n", e.Message);
                }
            }

            if (lives == 0)
            {
                AnimateLoss();
                Console.WriteLine("Oh no! You're dead! The word was {0}", word);
            }
        }

        private static void DrawBody(int incorrectGuesses)
        {
            switch (incorrectGuesses)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("  ");
                    Console.WriteLine("  ");
                    Console.WriteLine("  ");
                    Console.WriteLine("  ");
                    Console.WriteLine("  ");
                    Console.WriteLine("  ");
                    Console.WriteLine("  ");
                    Console.WriteLine("____");
                    break;
                case 2:
                    Console.WriteLine("  ");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 3:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 4:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 5:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 6:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 7:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |    \\|");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 8:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |    \\|/");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 9:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |    \\|/");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |    /");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 10:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |    \\|/");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |    / \\");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                default:
                    break;
            }
        }

        private static void AnimateLoss()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                Console.WriteLine("   _____");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |    \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |    / \\");
                Console.WriteLine("  |");
                Console.WriteLine("__|__");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("   _____");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |    /|\\");
                Console.WriteLine("  |    / \\");
                Console.WriteLine("  |");
                Console.WriteLine("__|__");
                Thread.Sleep(200);
            }

            Console.WriteLine("Rest in Peace");
        }

        private static void AnimateWin()
        {
            Console.Clear();
            Console.WriteLine("   _____");
            Console.WriteLine("  |     |");
            Console.WriteLine("  |     O");
            Console.WriteLine("  |    \\|/");
            Console.WriteLine("  |     |");
            Console.WriteLine("  |    / \\");
            Console.WriteLine("  |");
            Console.WriteLine("__|__");
            Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine("   _____");
            Console.WriteLine("  |     ");
            Console.WriteLine("  |     O");
            Console.WriteLine("  |    \\|/");
            Console.WriteLine("  |     |");
            Console.WriteLine("  |    / \\");
            Console.WriteLine("  |");
            Console.WriteLine("__|__");
            Thread.Sleep(100);

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine("   _____");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |    /|\\");
                Console.WriteLine("  |     |");
                Console.WriteLine("__|__  | |");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("   _____");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |    \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("__|__  | |");
                Thread.Sleep(200);
            }

            Console.WriteLine("I'm free!");
        }
    }
}