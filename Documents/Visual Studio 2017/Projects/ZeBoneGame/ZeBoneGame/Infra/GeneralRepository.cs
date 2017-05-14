using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeBoneGame.Infra
{
    public class Gr
    {
        public static LiteDatabase GetLiteDb()
        {
            return new LiteDatabase(@"C:\Users\avierin\Documents\tmp\MyBone.db");
        }
    }
}
