using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZeBoneGame.Model;
using System.IO;
using System.Collections.Generic;

namespace ZeBoneGame.Tests
{
    [TestClass]
    public class BoneImageRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var boneListRep = new BoneRepository();
            var boneList = boneListRep.GetBones();

            var boneImageRep = new BoneImageWebRepository();

            foreach (var bone in boneList)
            {
                if (Directory.Exists(boneImageRep.GetBoneImageDirectory(bone)))
                    continue;

                boneImageRep.GetImage(bone);
            }
        }


        [TestMethod]
        public void AllBonesHaveAnImage()
        {
            var boneRep = new BoneRepository();
            var boneImageWebRep = new BoneImageWebRepository();
            var boneImageFileRep = new BoneImageFileRepository();

            var boneList = boneRep.GetBones();
            var listBoneWithImageMissing = new List<string>();
            foreach (var bone in boneList)
            {
                if (!Directory.Exists(boneImageWebRep.GetBoneImageDirectory(bone)))
                {
                    listBoneWithImageMissing.Add(bone);
                    continue;
                }

                if (!File.Exists(boneImageFileRep.GetFirstImagePath(bone)))
                {
                    listBoneWithImageMissing.Add(bone);

                }
            }

            Assert.AreEqual(0, listBoneWithImageMissing.Count,
                string.Join(";", listBoneWithImageMissing));

        }




        private bool IsBlack(Bitmap bmp)
        {
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Scanning for non-zero bytes
            bool allBlack = true;
            for (int index = 0; index < rgbValues.Length; index++)
                if (rgbValues[index] != 0)
                {
                    allBlack = false;
                    break;
                }
            // Unlock the bits.
            bmp.UnlockBits(bmpData);
            return allBlack;
        }
    }
}
