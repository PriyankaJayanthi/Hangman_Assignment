﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare variable
            Random randGen = new Random();
            bool isAlive = true; 
            string[] wordslist = { "Orange", "John", "flower", "sweden", "butter", "book", "water", "pencile", "banana","apple" };  //Creating array with 10 different words to guess.

            Console.WriteLine("******** Welcom to Hungman game ********* ");
            // To play or exit game
            while (isAlive)
            {
                Console.WriteLine("To play game press 1 or press 2 to exit");
                int.TryParse(Console.ReadLine(), out int selection);
                switch(selection)
                {
                    case 1:
                        playgame(wordslist[randGen.Next(0, 9)]);
                        break;
                    case 2:
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
            int i, j = 0    ;
            char inputletter;
            int matched_count = 0;

            // Create guess word
            StringBuilder guessword = new StringBuilder(randword.Length);       

            // Create empty guess word so that user know how many char to guess
            for ( i = 0; i < randword.Length; i++)
                guessword.Append('_');
            Console.WriteLine(guessword);

            while(j < 10)
            {
                bool guessedcorrect = false;
                bool guesscheck = false;

                //Taking input from the user
                Console.WriteLine("Try {0} : Enter the guess letter", j);

                //Request user to input Character 
                inputletter = Console.ReadLine()[0];

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
                        guessword[i] = inputletter;
                        matched_count++;
                        guessedcorrect = true;
                    }
                }

                // If player guess right word 
                if (randword.Length == matched_count)
                {
                    Console.WriteLine("Game won");
                    break;
                }

                // Display each round Result 
                if (guessedcorrect)
                {
                    Console.WriteLine("The guess was correct : {0}", guessword);
                }
                else
                {
                    Console.WriteLine("The guess was incorrect : {0}", guessword);
                }

                // Incerement chances 
                j++;
                
            }
              if (randword.Length != matched_count)
            {
                Console.WriteLine("Lost the game");
                
            }
        }
    }
}


