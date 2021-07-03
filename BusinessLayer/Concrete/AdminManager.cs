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
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;

        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }

        public void AdminAdd(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetAdmin(string username, string password)
        {
            return _admindal.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }

        public Admin GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            return _admindal.List();
        }

        public Admin Roless(string username)
        {
            return _admindal.Get(x => x.AdminUserName == username);
        }
    }
}
