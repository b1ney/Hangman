using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            GuessCommand = new RelayCommand(Guess, CanGuess);
            ResetCommand = new RelayCommand(Reset);
            Init();
        }

        private string word;
        public string Word
        {
            get { return word; }
            set { Set(ref word, value); }
        }


        private string guessed;
        public string Guessed
        {
            get { return guessed; }
            set { Set(ref guessed, value); }
        }

        private string input;
        public string Input
        {
            get { return input; }
            set
            {
                SetProperty(value, ref input, nameof(Input));
                GuessCommand.RaiseCanExecuteChanged();
            }
        }

        private string rem;
        public string RemainingGuesses
        {
            get { return rem; }
            set { SetProperty(value, ref rem, nameof(RemainingGuesses)); }
        }

        private Game game;
        public RelayCommand GuessCommand { get; private set; }
        public RelayCommand ResetCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty(string value, ref string property, string name)
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Init()
        {
            game = new Game();
            Word = game.ProgressString;
            Guessed = "-";
            RemainingGuesses = $"Remaining guesses: {game.RemainingGuesses}";
        }

        private void Guess(object obj)
        {
            Word = game.Guess(Input[0]);
            RemainingGuesses = $"Remaining guesses: {game.RemainingGuesses}";
            
        }

        private bool CanGuess(object obj)
        {
            return Input?.Length > 0 && !game.HasAlreadyGuessed(Input[0]) && game.RemainingGuesses > 0;
        }

        private void Reset(object obj)
        {
            Init();
        }
    }
}
