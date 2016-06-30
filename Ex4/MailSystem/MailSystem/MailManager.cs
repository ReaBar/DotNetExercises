using System;

namespace MailSystem
{
    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;
        
        public void SimulatedMailArrived()
        {
            OnMailArrived(new MailArrivedEventArgs("Dummy Data", "Dummy Data"));
        }

        protected virtual void OnMailArrived(MailArrivedEventArgs mail)
        {
            if(mail != null)
            {
                MailArrived?.Invoke(this, mail);
            }
        }
    }

    public class MailArrivedEventArgs : EventArgs
    {
        public MailArrivedEventArgs(string title,string body)
        {
            Title = title;
            Body = body;
        }
        public string Title { get; }

        public string Body { get; }
    }
}
