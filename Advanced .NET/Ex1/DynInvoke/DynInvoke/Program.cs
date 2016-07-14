using System;

namespace DynInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();

            InvokeHello(a, "Rea");
            InvokeHello(b, "Rea");
            InvokeHello(c, "Rea");
        }

        public static void InvokeHello(object obj, string str)
        {
            if(obj?.GetType().GetMethod("Hello") != null && !string.IsNullOrWhiteSpace(str))
            {
                var result = obj.GetType().GetMethod("Hello").Invoke(obj, new object[] { str });
                var inputStr = result as string;
                if (!string.IsNullOrWhiteSpace(inputStr))
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
