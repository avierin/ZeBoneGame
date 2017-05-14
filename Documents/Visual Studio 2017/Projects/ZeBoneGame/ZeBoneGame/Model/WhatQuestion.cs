namespace ZeBoneGame.Model
{
    public class WhatQuestion
    {
        public WhatQuestion()
        {

        }

        public WhatQuestion(string  answer, string[] imageLocations)
        {
            Answer = answer;

            ImageLocaltion = imageLocations;
        }

        public int Id { get; set; }
        public string Answer { get; set; }
        public string[] ImageLocaltion { get; set; }

        public  bool isValid(string userAnswer)
        {
            return Answer.ToLowerInvariant() == userAnswer.ToLowerInvariant();
        }
    }
}

