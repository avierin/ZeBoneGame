using System.Collections.Generic;
using System.Drawing;

namespace ZeBoneGame.Model
{
    public abstract class BoneImageRepositoryBase
    {
        public abstract List<Bitmap> GetImage(string bone);
        public abstract void AddImage(string bone, Bitmap image);

    }
}