using System.Text;

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
