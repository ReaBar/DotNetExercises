using System;

namespace MailSystem
{
    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;
        
        public void SimulatedMailArrived()
        {
            OnMailArrived(new MailArrivedEventArgs("dummy title", "dummy body"));
        }

        protected virtual void OnMailArrived(MailArrivedEventArgs mail)
        {
            if(MailArrived != null)
            {
                MailArrived(this, mail);
            }
        }
    }

    public class MailArrivedEventArgs : EventArgs
    {
        private string _title,_body;
        public MailArrivedEventArgs(string title,string body)
        {
            _title = title;
            _body = body;
        }
        public string Title => _title;
        public string Body => _body;
    }
}
