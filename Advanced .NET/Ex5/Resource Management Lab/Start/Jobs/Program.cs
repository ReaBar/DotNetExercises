using System;
using System.Diagnostics;

namespace Jobs {
	class Program {
		static void Main(string[] args)
        {
            Job myJob = new Job("manage_resources");
            myJob.AddProcessToJob(Process.Start("notepad"));
            myJob.AddProcessToJob(Process.Start("calc"));
            Console.WriteLine("Press enter to kill the job");
		    Console.ReadLine();
            myJob.Kill();
		    uint count = 0;
            for (uint i = 0; i <= 20; i++)
            {
                var newJob = new Job(count);
                count += 500000;
            }
		    Console.ReadLine();
        }
    }
}
