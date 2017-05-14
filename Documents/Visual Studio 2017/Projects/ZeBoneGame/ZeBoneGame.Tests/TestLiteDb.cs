using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiteDB;
using ZeBoneGame.Model;
using System.Collections.Generic;
using ZeBoneGame.Infra;

namespace ZeBoneGame.Tests
{
    [TestClass]
    public class TestLiteDb
    {
        [TestMethod]
        public void RemplirLiteDB()
        {

            var boneSeeder = new BoneRepository();
            var boneSeeds = boneSeeder.GetBones();

            // Open database(or create if not exits)
            using (var db = Gr.GetLiteDb())
            {


                // Get bones collection
                var bones = db.GetCollection<Bone>("bones");

                // Insert new bone document (Id will be auto-incremented)
                boneSeeds.ForEach(b => bones.Upsert(new Bone() { Name = b }));


                // Index document using a document property
                bones.EnsureIndex(x => x.Name);

                // Use Linq to query documents
                var results = new List<Bone>(bones.Find(x => x.Name.StartsWith("P")));

                Assert.IsNotNull(results.Find(b=> b.Name == "Patella"));


                var boneImages = db.GetCollection<BoneImage>("boneImages");

                var boneImageRep = new BoneImageFileRepository();
                foreach (var boneName in boneSeeds)
                {
                    var boneImagePaths = boneImageRep.GetAllFilePath(boneName);
                    Assert.IsFalse(boneImagePaths.Count == 0);

                    Bone bone = bones.FindOne(x => x.Name == boneName);
                    foreach (string path in boneImagePaths)
                    {
                        var boneImage = new BoneImage() { BoneId = bone.Id, FilePath = path };
                        boneImages.Insert(boneImage);

                    }
                }

                boneImages.EnsureIndex(x => x.BoneId);
            }
            


        }

        [TestMethod]
        public void TestPatellaImages()
        {
            // Open database(or create if not exits)
            using (var db = Gr.GetLiteDb())
            {
                const string fileLocation = @"C: \Users\avierin\Documents\tmp\BoneImages\Patella\Patella_";
                var patellaImages = db.GetCollection<BoneImage>("Patella");
                    for(int i=0; i< patellaImages.Count(); i++)
                {
                    Assert.IsNotNull(patellaImages.FindOne(x => x.FilePath == fileLocation + i));
                }
                       
            }
        }
    }
}
