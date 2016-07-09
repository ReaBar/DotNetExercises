using System.Text;

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
