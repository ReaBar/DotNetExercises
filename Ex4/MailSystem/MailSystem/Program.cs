using System;
using MailSystem;
using System.Threading;

namespace MailSystem
{
    class Program
    {
        private static Timer _timer;
        static void Main(string[] args)
        {
            MailManager _mailManager = new MailManager();
            _mailManager.MailArrived += PrintMail;

            _mailManager.SimulatedMailArrived();

            _timer = new Timer(Callback, _mailManager, 1000, 1000);
            Console.ReadLine();
        }

        private static void Callback(object state)
        {
            if(state != null && state is MailManager)
            {
               ((MailManager)state).SimulatedMailArrived();
            }
        }

        static void PrintMail(object sender,MailArrivedEventArgs mailArrived)
        {
            System.Console.WriteLine("The mail title is: {0} and the body: {1}", mailArrived.Title, mailArrived.Body);
        }
    }
}
