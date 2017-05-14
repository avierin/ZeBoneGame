using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeBoneGame.Model;

namespace ZeBoneGame.Tests
{
    [TestClass]
    public class BoneRepositoryTest
    {
        [TestMethod]
        public void TestBoneList()
        {
            var boneRep = new BoneRepository();

            Assert.AreEqual(120, boneRep.GetBones().Count);
        }
    }
}
