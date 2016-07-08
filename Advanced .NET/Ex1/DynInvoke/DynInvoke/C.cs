using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class C
    {
        public string Hello(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nihau ");
            sb.Append(str);
            return sb.ToString();
        }
    }
}
