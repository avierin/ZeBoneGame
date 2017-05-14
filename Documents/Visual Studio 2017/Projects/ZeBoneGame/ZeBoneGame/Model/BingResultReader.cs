using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ZeBoneGame.Model
{
    public class BingResultReader
    {


        public string[] ExtraireWebUrl(string jsonString)
        {
            List<string> urls = new List<string>();
            var ser = new JavaScriptSerializer();
            var result = ser.DeserializeObject(jsonString);
            Dictionary<string, object> resultDic = result as Dictionary<string, object>;
            var values = resultDic["value"] as object[];
            

            foreach (var objectDic in values)
            {
                var dic = objectDic as Dictionary<string, object>;
                urls.Add(dic["contentUrl"] as string);
            }
           // result[8];
            return urls.ToArray();

        }
    }
}
