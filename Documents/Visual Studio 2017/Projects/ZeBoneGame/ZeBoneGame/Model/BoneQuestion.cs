using System.Drawing;

namespace ZeBoneGame.Model
{
    public class BoneQuestion
    {
        private string _question = "What is this bone ?";
        private string _boneName;

        public string ImagePath { get; private set; }


        public BoneQuestion(string boneName)
        {
            BoneImageFileRepository boneImageRepository = new BoneImageFileRepository();

            BoneName = boneName;
            ImagePath = boneImageRepository.GetFirstImagePath(boneName);
           

        }

        public string BoneName { get => _boneName; set => _boneName = value; }
        public string Title { get => _question; }

        public bool isValid(string userAnswer)
        {
            return BoneName.ToLower() == userAnswer.ToLower();
        }

        public override string ToString()
        {
            return "Q: " + BoneName;
        }
    }
}