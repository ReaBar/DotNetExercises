﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class B
    {
        public string Hello(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Bonjour ");
            sb.Append(str);
            return sb.ToString();
        }
    }
}
