using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct,
                       AllowMultiple = true)]

    class CodeReviewAttribute : System.Attribute
    {
        private string reviewrName;
        private string reviewDate;
        private bool codeApproved;

        public CodeReviewAttribute(string name, string date, bool codeApprove)
        {
            reviewrName = name;
            reviewDate = date;
            codeApproved = codeApprove;
        }

        public string ReviewrName => reviewrName;
        public string ReviewDate => reviewDate;
        public bool CodeApproved => codeApproved;
    }
}
