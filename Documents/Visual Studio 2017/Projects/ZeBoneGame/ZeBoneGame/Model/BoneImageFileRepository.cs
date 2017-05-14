using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ZeBoneGame.Model
{
    public class BoneImageFileRepository : BoneImageRepositoryBase
    {
        private string _defaultDiskLocaltion = ImageDb.DefautDirectory;

        public override void AddImage(string bone, Bitmap image)
        {
            var existingImages = GetImage(bone);
            var nextImageName = bone + "_" + (existingImages.Count + 1);
            var localtion = Path.Combine(_defaultDiskLocaltion, nextImageName);


            image.Save(localtion);
        }

        public string GetFirstImagePath(string bone)
        {
            string firstImage;

            firstImage = Path.Combine(_defaultDiskLocaltion, bone);
            firstImage = Path.Combine(firstImage, bone + "_1.bmp");

            return firstImage;

        }

        public List<string> GetAllFilePath(string bone)
        {
           return new List<string>( 
               Directory.GetFiles(
                   Path.Combine(_defaultDiskLocaltion,bone),
                   bone + "*")
                   );
        }

        public override List<Bitmap> GetImage(string bone)
        {
            var imageFiles = GetAllFilePath(bone);

            return imageFiles.ConvertAll(s => new Bitmap(s));

        }

    }
}
