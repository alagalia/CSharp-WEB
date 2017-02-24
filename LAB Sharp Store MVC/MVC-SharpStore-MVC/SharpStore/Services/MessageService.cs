using SharpStore.BindingModels;
using SharpStore.Data;
using SharpStore.Models;

namespace SharpStore.Services
{
    public class MessageService : Service
    {

        public MessageService(SharpStoreContext2 context) : base(context)
        {
        }

        public void AddMessageFromBind(MessageBindinModel model)
        {
            Message message = new Message()
            {
                MessageText = model.MessageText,
                Email = model.Email,
                Subject = model.Subject
            };
            Context.Messages.Add(message);
            Context.SaveChanges();
        }

    }
}