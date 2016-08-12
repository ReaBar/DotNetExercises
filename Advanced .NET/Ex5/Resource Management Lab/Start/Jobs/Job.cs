using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Jobs
{
    static class NativeJob
    {
        [DllImport("kernel32")]
        public static extern IntPtr CreateJobObject(IntPtr sa, string name);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AssignProcessToJobObject(IntPtr hjob, IntPtr hprocess);

        [DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr h);

        [DllImport("kernel32")]
        public static extern bool TerminateJobObject(IntPtr hjob, uint code);
    }

    public class Job : IDisposable
    {
        private readonly IntPtr _hJob;
        private readonly List<Process> _processes;
        private bool _disposed;
        private readonly uint _sizeInBytes = 0;

        public Job(string name)
        {
            _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
            if (_hJob.ToInt32() == 0)
            {
                throw new InvalidOperationException();
            }
            _processes = new List<Process>();
        }

        public Job(uint sizeInBytes)
        {
            if(sizeInBytes == 0) return;
            _sizeInBytes = sizeInBytes;
            CreateJobWithBytes();
        }

        public Job()
            : this(null)
        {
        }

        private void CreateJobWithBytes()
        {
            GC.AddMemoryPressure(_sizeInBytes);
            Console.WriteLine($"Job {_sizeInBytes} was created.");
        }

        protected void AddProcessToJob(IntPtr hProcess)
        {
            CheckIfDisposed();

            if (!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
            {
                Console.WriteLine(new Win32Exception(Marshal.GetLastWin32Error()).Message);
                throw new InvalidOperationException("Failed to add process to job");
            }
        }

        private void CheckIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(typeof(Job).ToString());
            }
        }

        public void AddProcessToJob(int pid)
        {
            CheckIfDisposed();
            AddProcessToJob(Process.GetProcessById(pid));
        }

        public void AddProcessToJob(Process proc)
        {
            CheckIfDisposed();
            Debug.Assert(proc != null);
            AddProcessToJob(proc.Handle);
            _processes.Add(proc);
        }

        public void Kill()
        {
            NativeJob.TerminateJobObject(_hJob, 0);
            Dispose();
            NativeJob.CloseHandle(_hJob);
        }

        public void Dispose()
        {
            CheckIfDisposed();
            _disposed = true;
            Dispose(_disposed);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_processes == null) return;
                _processes.ForEach(p => { p.Dispose(); });
                _processes.Clear();
            }
        }

        ~Job()
        {
            try
            {
                GC.RemoveMemoryPressure(_sizeInBytes);
                Console.WriteLine($"Job {_sizeInBytes} was released");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Caught ArugumentOutOfRaneException: {e.Message}");
            }
        }
    }
}
