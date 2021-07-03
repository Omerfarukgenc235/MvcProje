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
    public class ContactManager : IContactService
    {
        IContactDal _ContactDal;

        public ContactManager(IContactDal ContactDal)
        {
            _ContactDal = ContactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _ContactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _ContactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _ContactDal.Delete(contact);
        }

        public Contact GetByID(int id)
        {
            return _ContactDal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _ContactDal.List();
        }
    }
}
