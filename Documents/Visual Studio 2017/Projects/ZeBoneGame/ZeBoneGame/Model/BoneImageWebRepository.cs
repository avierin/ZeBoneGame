using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web;

namespace ZeBoneGame.Model
{
    public class BoneImageWebRepository : BoneImageRepositoryBase
    {

        public string ImagesDirectory { get; set; }
        public int ImageNbPerBone { get; set; }

        public BoneImageWebRepository()
        {
            ImagesDirectory = ImageDb.DefautDirectory;

            ImageNbPerBone = 10;
        }


        public override List<Bitmap> GetImage(string bone)
        {

            Console.WriteLine("GetImage " + bone);
            string boneName = bone + " + bone";
            string queryFullString = "?q=" + boneName + "&count=" + ImageNbPerBone;

            var queryString = HttpUtility.ParseQueryString(queryFullString);

            var client = new HttpClient();
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "64b11dfdace64d2dbc04c6a708e9fe2b");

            var uri = "https://api.cognitive.microsoft.com/bing/v5.0/images/search?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = client.PostAsync(uri, content).Result;
            }

            string jsonResponse = response.Content.ReadAsStringAsync().Result;

#if DEBUGRESPONSE
            using (var streamWriter = new StreamWriter(@"C:\Users\avierin\Documents\tmp\testBing.txt"))
            {
                streamWriter.Write(jsonResponse);
            };
#endif

            string boneDirectory = GetBoneImageDirectory(bone);

            if (!Directory.Exists(boneDirectory))
                Directory.CreateDirectory(boneDirectory);

            var resultReader = new BingResultReader();
            var imagesUrls = resultReader.ExtraireWebUrl(jsonResponse);

            int i = 0;
            foreach (var imageUrl in imagesUrls)
            {
                try
                {
                    string boneImageFile = boneDirectory + "\\" + bone + "_" + i++ + ".bmp";
                    if (File.Exists(boneImageFile))
                        continue;

                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(new Uri(imageUrl), boneImageFile);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            Thread.Sleep(200);

            return new List<Bitmap>();
        }

        public string GetBoneImageDirectory(string bone)
        {
            return Path.Combine(ImagesDirectory, bone);
        }

        private string GetSearchBoneUrl(string bone)
        {
            string request = bone + "%20" + "bone";
            return "https://yandex.com/images/search?text="+ request
                +"&parent-reqid=1491463375881282-445460217617956085246233-sas1-5977";        }

        

        public override void AddImage(string bone, Bitmap image)
        {
            throw new NotImplementedException();
        }
    }
}
