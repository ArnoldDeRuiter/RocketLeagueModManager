using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueModManager
{
    class Json
    {
        public string[] GetIgnored()
        {
            string json;
            using (StreamReader r = new StreamReader("ignore.json"))
            {
                json = r.ReadToEnd();
            }
            return JArray.Parse(json).ToObject<string[]>();
        }
    }
}
