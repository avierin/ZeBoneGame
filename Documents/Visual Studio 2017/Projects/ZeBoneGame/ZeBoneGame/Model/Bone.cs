namespace ZeBoneGame.Model
{
    public class Bone
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name + " id:" +Id;
        }
    }


    public class BoneImage
    {
        public int BoneId { get; set; }
        public string FilePath { get; set; }

        public override string ToString()
        {
            return "boneid: " + BoneId + " " + FilePath;
        }
    }
}
