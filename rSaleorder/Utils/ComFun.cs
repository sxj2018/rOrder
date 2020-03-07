using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class ComFun
    {
        /// <summary>
        /// 字符串转为hastable
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static Hashtable StrToHasTable(string strJson)
        {
            if (strJson == null)
                strJson = "{}";
            if (strJson.Length == 0)
                return default(Hashtable);
            return JsonConvert.DeserializeObject<Hashtable>(strJson);
        }


    }
}
