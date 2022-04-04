using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
// Hangman program for gussing a word
// 2022-03-29 PriyankaJ
namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {

                // Declare variable
                Random randGen = new Random();
                bool isAlive = true;
                string[] wordslist = { "Orange", "John", "flower", "sweden", "butter", "book", "water", "pencile", "banana", "apple" };  //Creating array with 10 different words to guess.

                Console.WriteLine("******** Welcom to Hungman game ********* ");
                // To play or exit game
                while (isAlive)
                {
                    Console.WriteLine("To play game press 1 or press any key to exit");
                    int.TryParse(Console.ReadLine(), out int selection);
                    switch (selection)
                    {
                        case 1:
                            playgame(wordslist[randGen.Next(0, 9)].ToUpper());
                            break;
                    default:
                            isAlive = false;
                            break;
                    }
                }
                Console.WriteLine("Thanks for playing the game");
        }

        static void playgame(string randword)
        {
            // Declare variables
            List<char> guessletter = new List<char>();
            int i;
            int j = 10;
            char inputletter;
            int matched_count = 0;
            //int num_0f_chances = 11;
            // To store incorrect word
            StringBuilder incrtLetter = new StringBuilder();
            // Character array to store the guess word. 
            char[] correctguess = new char[randword.Length];

            // Create empty guess word so that user know how many char to guess
            for ( i = 0; i < randword.Length; i++)
            {
                correctguess[i] = '_';
            }

            Console.WriteLine("Word to be guessed: \n");
            foreach (char r in correctguess)
            {
                Console.Write("{0} ", r);
            }

            Console.WriteLine("\n");

            while (j >= 1)
            {
                bool guessedcorrect = false;
                bool guesscheck = false;

                //Taking input from the user
                
                //Request user to input Character 
                Console.WriteLine("Number of chanses left {0} : Enter the guess letter", j);
                inputletter = char.ToUpper(Console.ReadLine()[0]);
  
                    //if user has already choosed the input character
                    for (i = 0; i < guessletter.Count; i++)
                {
                    if (guessletter[i] == inputletter)
                    {
                        Console.WriteLine("Already the word was choosen");
                        guesscheck = true;
                        break;
                    }
                }
                if (guesscheck)
                    continue;

                // Add input to the list 
                guessletter.Add(inputletter);

                // Matching the guessing letter with random word
                for (i = 0; i < randword.Length; i++)
                {
                    if (randword[i] == inputletter)
                    {
                        correctguess[i] = inputletter;
                        matched_count++;
                        guessedcorrect = true;
                    }
                }

                // Store incorrect word in the string builder.
                if (!guessedcorrect)
                    incrtLetter.Append(inputletter);

                // If player guess right word 
                if (randword.Length == matched_count)
                {
                    Console.WriteLine("******* Game won ********");
                    foreach (char r in correctguess)
                    {
                        Console.Write("{0}", r);
                    }
                    Console.WriteLine("\n");
                    break;
                }

                // Display each round Result 
                if (guessedcorrect)
                {
                    Console.WriteLine("The guess was correct : ");
                    foreach (char r in correctguess)
                    {
                        Console.Write("{0} ", r);
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("The guess was incorrect : {0}", incrtLetter);
                }

                // Incerement chances    
                j--;
                
            }
              if (randword.Length != matched_count)
            {
                Console.WriteLine("************ Lost the game **************");
                
            }
        }
    }
}


