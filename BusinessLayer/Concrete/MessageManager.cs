using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public Message GetByID(int id)
        {
            return _messagedal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messagedal.List(x => x.ReceiverMail == p);
        }


        public List<Message> GetSendInbox(string p)
        {
            return _messagedal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public List<Message> MessageNoRead(string p)
        {
            return _messagedal.List(x => x.ReceiverMail == p).Where(y => y.MessageRead == true).ToList();
        }

        public List<Message> MessageRead(string p)
        {
            return _messagedal.List(x => x.ReceiverMail == p).Where(y => y.MessageRead == false).ToList();
        }

        public void MessageUpdate(Message message)
        {
            _messagedal.Update(message);
        }
    }
}
