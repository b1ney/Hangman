using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Game
    {
        string secretWord;
        char[] guessed;
        char[] guessedChars;
        int remainingGuesses = 11;

        public Game()
        {
            string[] words = Properties.Resources.words.Split('\n');
            secretWord = words[new Random().Next(1, words.Length)];
            guessed = new char[words.Length * 2];
            guessedChars = new char[26];
            InitiateViewString();
        }

        public string Guess(char c)
        {
            if (--remainingGuesses >= 0)
            {
                guessedChars[guessedChars.Length - 1] = c;
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (guessed[i] == '_' && secretWord[i] == c)
                    {
                        guessed[i] = secretWord[i];
                    }
                }
            }
            return ProgressString;
        }

        public void InitiateViewString()
        {
            for (int i = 0; i < guessed.Length / 2; i += 2)
            {
                guessed[i] = '_';
            }
            for (int i = 1; i < guessed.Length / 2; i+= 2)
            {
                guessed[i] = ' ';
            }
        }

        public bool HasAlreadyGuessed(char c)
        {
            return guessedChars.Contains(c);
        }

        public string ProgressString
        {
            get { return new string(guessed); }
        }

        public int RemainingGuesses
        {
            get { return remainingGuesses; }
        }
    }
}
