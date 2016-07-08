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

        public static void InvokeHello(Object obj, string str)
        {
            if(obj != null && obj.GetType().GetMethod("Hello") != null)
            {
                var result = obj.GetType().GetMethod("Hello").Invoke(obj, new object[] { str });
                if (result is string && !string.IsNullOrWhiteSpace((string)result))
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
