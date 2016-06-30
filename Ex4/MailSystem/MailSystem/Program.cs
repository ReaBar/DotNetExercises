using System;
using System.Threading;

namespace MailSystem
{
    class Program
    {
        private static Timer _timer;
        static void Main(string[] args)
        {
            Program program = new Program();
            MailManager mailManager = new MailManager();
            mailManager.MailArrived += (sender, mailArrived) => { System.Console.WriteLine("The mail title is: {0} and the body: {1}", mailArrived.Title, mailArrived.Body); };

            mailManager.SimulatedMailArrived();

            _timer = new Timer(program.SimulateMailCallback, mailManager, 1000, 1000);
            Console.ReadLine();
        }

        private void SimulateMailCallback(object state)
        {
            (state as MailManager)?.SimulatedMailArrived();
        }
    }
}
