using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.TemplateGenerator.Classes.Mediation
{
    public class FormMediator
    {

        static FormMediator _instance;
        public EventHandler<MessageEventArgs> BroadCastMessageEvent;
        public EventHandler<MessageEventArgs> BroadCastErrorEvent;
        public EventHandler<MessageEventArgs> GenerationScreenEvent;
        public EventHandler<MessageEventArgs> GenerationCompleteEvent;
        private FormMediator()
        {
        }

        public static FormMediator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FormMediator();
            }
            return _instance;
        }

        public void SendMessage(string message)
        {
            if (this.BroadCastMessageEvent != null)
            {
                MessageEventArgs me = new MessageEventArgs();
                me.Message = message;
                this.BroadCastMessageEvent(this, me);
            }
        }

        public void SendError(string message)
        {
            if (this.BroadCastErrorEvent != null)
            {
                MessageEventArgs me = new MessageEventArgs();
                me.Message = message;
                this.BroadCastErrorEvent(this, me);
            }
        }

        public void AddGenerationScreenMessage(string message)
        {
            if (this.GenerationScreenEvent != null)
            {
                MessageEventArgs me = new MessageEventArgs();
                me.Message = message;
                this.GenerationScreenEvent(this, me);
            }
        }

        public void GenerationComplete()
        {
            if (this.GenerationCompleteEvent != null)
            {
                this.GenerationCompleteEvent(this,new MessageEventArgs());
            }
        }

    }
}
