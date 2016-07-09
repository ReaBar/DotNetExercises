using System.Text;

namespace DynInvoke
{
    class A
    {
        public string Hello(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello ");
            sb.Append(str);
            return sb.ToString();
        }
    }
}
