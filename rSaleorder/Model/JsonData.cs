using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JsonData
    {
        public int code { get; set; }

        public int count { get; set; }

        public object data { get; set; }

        public string msg { get; set; }

     
        public JsonData()
        {
            this.code = 0;
            this.data = (object)new ArrayList();
        }

    }
}
