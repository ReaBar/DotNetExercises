using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Jobs {
	static class NativeJob {
		[DllImport("kernel32")]
		public static extern IntPtr CreateJobObject(IntPtr sa, string name);

		[DllImport("kernel32", SetLastError = true)]
		public static extern bool AssignProcessToJobObject(IntPtr hjob, IntPtr hprocess);

		[DllImport("kernel32")]
		public static extern bool CloseHandle(IntPtr h);

		[DllImport("kernel32")]
		public static extern bool TerminateJobObject(IntPtr hjob, uint code);
}

	public class Job : IDisposable{
		private IntPtr _hJob;
		private List<Process> _processes;
	    private bool _disposed;

		public Job(string name)
		{
            //TODO to make sure this is what they ment when they said "b.	If the handle is zero (IntPtr.Zero), throw an InvalidOperationException"
            if (IntPtr.Zero == null)
		    {
		        throw new InvalidOperationException();
		    }

		    _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
            _processes = new List<Process>();
		}

		public Job()
			: this(null) {
		}

		protected void AddProcessToJob(IntPtr hProcess) {
			CheckIfDisposed();

			if(!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
				throw new InvalidOperationException("Failed to add process to job");
		}

	    private void CheckIfDisposed()
	    {
	        throw new NotImplementedException();
	    }

	    public void AddProcessToJob(int pid) {
	        if (_disposed)
	        {
	            throw new ObjectDisposedException(typeof(Job).ToString());
	        }
			AddProcessToJob(Process.GetProcessById(pid));
		}

		public void AddProcessToJob(Process proc) {
            if (_disposed)
            {
                throw new ObjectDisposedException(typeof(Job).ToString());
            }
            Debug.Assert(proc != null);
			AddProcessToJob(proc.Handle);
			_processes.Add(proc);
		}

		public void Kill()
		{
		    NativeJob.TerminateJobObject(IntPtr.Zero, 0);
		}

	    public void Dispose()
	    {
	        if (!_disposed)
	        {
                _disposed = true;
                Dispose(_disposed);
                GC.SuppressFinalize(this);
	        }
	    }

	    protected virtual void Dispose(bool disposing)
	    {
            if (disposing)
            {
                if (_processes != null)
                {
                    foreach (var process in _processes)
                    {
                        process.Dispose();
                    }
                }
            }
        }
	}
}
