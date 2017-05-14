using ZeBoneGame.Model;
using System.Windows.Input;
using ZeBoneGame.Infra;
using System;

namespace ZeBoneGame.ViewModel
{
    public class GameViewModel : BindableBase
    {
        private BoneGame _game;
        private string _userAnswer;
        private const string _defautAnswer = "????";
        private string _currentStatus;
        private bool _showAnswer = false;
             

        public ICommand ValidateAnswer => new RelayCommand(() => ValidateUserAnswer());
        public ICommand GoToNextQuestion => new RelayCommand(() => NextQuestion());

        public BoneGame Game { get => _game; set => _game = value; }
        public string CurrentStatus
        {
            get => _currentStatus;
            set => SetProperty(ref _currentStatus, value, "CurrentStatus");

        }
                      
        public bool ShowAnswer
        {
            get => _showAnswer;
            set => SetProperty(ref _showAnswer, value, "ShowAnswer");
        }
        
        public GameViewModel()
        {
            Game = new BoneGame();
            UserAnswer = _defautAnswer;
            ShowOkButton = true;
            UpdateCurrentStatus();
        }

        private void NextQuestion()
        {
            LastAnswerValid =  Game.ValidateAnswer(UserAnswer);

            ShowAnswer = false;
            ShowOkButton = true;
            UserAnswer = _defautAnswer;

            OnPropertyChanged("ShowOkButton");

            UpdateCurrentStatus();
        }



        private void UpdateCurrentStatus()
        {
            CurrentStatus = "Question: " + Game.CurrentNumber + " / " + Game.TotalQuestionNumber
                  + "\t Score: " + Game.Score + " / " + (Game.CurrentNumber - 1);
        }

        private void ValidateUserAnswer()
        {
            ShowAnswer = true;
            ShowOkButton = false;
            LastAnswerValid = Game.CurrentQuestion.Answer.ToLower() == UserAnswer.ToLower();
        }


        private bool _showOkButton;
        public bool ShowOkButton
        {
            get => _showOkButton;
            set => SetProperty(ref _showOkButton, value, "ShowOkButton");
        }


        public string UserAnswer
        {
            get { return _userAnswer; }
            set { SetProperty(ref _userAnswer, value, "UserAnswer"); }
        }

        private bool _lastAnswerValid;
        public bool LastAnswerValid
        {
            get => _lastAnswerValid;
            private set => SetProperty(ref _lastAnswerValid, value, "LastAnswerValid");
        }
    }
}
