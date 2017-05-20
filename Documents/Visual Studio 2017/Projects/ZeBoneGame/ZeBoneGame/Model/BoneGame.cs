using System;
using System.Collections.Generic;
using ZeBoneGame.Infra;

namespace ZeBoneGame.Model
{
    public class BoneGame : BindableBase
    {
        private List<WhatQuestion> _questions;

        private WhatQuestion _currentQuestion;
        private int _questionNumber = 20;
        private BoneRepository _boneRepository = new BoneRepository();
        private List<string> _bones = new List<string>();
        private List<int> _pickedBoneNumber;
        private int _score;

        public WhatQuestion CurrentQuestion
        {
            get { return _currentQuestion; }
            private set
            {
                SetProperty(ref _currentQuestion, value, "CurrentQuestion");
            }
        }
        public int CurrentNumber { get { return _questions.IndexOf(_currentQuestion) + 1; } }

        public int Score
        {
            get { return _score; }
            private set
            {
                SetProperty(ref _score, value, "Score");
            }
        }
        public int TotalQuestionNumber { get { return _questions.Count; } }

        public BoneGame()
        {
            _score = 0;
            _bones = _boneRepository.GetBones();
            _pickedBoneNumber = new List<int>();
            _questions = new List<WhatQuestion>();

            using (var db = Gr.GetLiteDb())
            {
                _questions.AddRange(db.GetCollection<WhatQuestion>("whatQuestions").FindAll());
            }

            _questions.Shuffle();
            _currentQuestion = _questions[0];
        }


        public bool ValidateAnswer(string userAnswer)
        {
            bool answerValid = _currentQuestion.isValid(userAnswer);

            if (answerValid)
                Score++;

            CurrentQuestion = _questions[CurrentNumber];

            return answerValid;
        }
    }
}
