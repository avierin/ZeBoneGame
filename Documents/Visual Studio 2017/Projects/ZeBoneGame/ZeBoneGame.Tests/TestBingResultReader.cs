using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ZeBoneGame.Model;

namespace ZeBoneGame.Tests
{
    [TestClass]
    public class TestBingResultReader
    {
        private string firstContentUrl = @"http://www.bing.com/cr?IG=D207D0CFEBEA450DBAF7027BE7AC3F43&CID=2BE8E8F615936DAB2B10E2AA14746C53&rd=1&h=Gq2P5rDXMkU50lkoV6sPh4g0Z6trz87d3ODbsFPyxnw&v=1&r=http%3a%2f%2fupload.wikimedia.org%2fwikipedia%2fcommons%2f0%2f01%2fNasal_bone.png&p=DevEx,5008.1";
        [TestMethod]
        public void TestParLExemple()
        {
            string json;
            using (var reader = new StreamReader("bingResultForTest.json"))
            {
                 json = reader.ReadToEndAsync().Result;
            }

            var resultReader = new BingResultReader();
            var urls = resultReader.ExtraireWebUrl(json);

            Assert.AreEqual(10, urls.Length);
            Assert.AreEqual(firstContentUrl, urls[0]);
        }
    }
}
