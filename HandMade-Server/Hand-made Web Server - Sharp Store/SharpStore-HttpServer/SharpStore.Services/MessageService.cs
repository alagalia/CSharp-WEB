using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpStore.Data;
using SharpStore.Data.Models;

namespace SharpStore.Services
{
    public class MessageService
    {
        private  SharpStoreContext context;

        public MessageService()
        {
            this.context = Data.Data.Context;
        }
        public void AddMessageFromContactForm(IDictionary<string, string> vars)
        {
            Message msg = new Message()
            {
                MessageText = vars["message-text"],
                Sender = vars["sender-email"],
                Subject = vars["subject"]
            };

            this.context.Messages.Add(msg);
            this.context.SaveChanges();
        }
    }
}
