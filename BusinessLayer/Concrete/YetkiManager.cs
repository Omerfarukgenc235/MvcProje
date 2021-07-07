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
    public class YetkiManager : IYetkiService
    {
        IYetkiDal _yetkidal;

        public YetkiManager(IYetkiDal yetkidal)
        {
            _yetkidal = yetkidal;
        }

        public List<Yetki> GetAll()
        {
            return _yetkidal.List();
        }
    }
}
