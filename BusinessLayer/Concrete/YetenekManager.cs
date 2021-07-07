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
    public class YetenekManager : IYetenekService
    {
        IYetenekDal _yetenekdal;

        public YetenekManager(IYetenekDal yetenekdal)
        {
            _yetenekdal = yetenekdal;
        }

        public void Delete(Yetenek yetenek)
        {
            _yetenekdal.Delete(yetenek);
        }

        public List<Yetenek> GetYeteneks()
        {
            return _yetenekdal.List();
        }

        public void Update(Yetenek yetenek)
        {
            _yetenekdal.Update(yetenek);
        }

        public void YetenekAdd(Yetenek yetenek)
        {
            _yetenekdal.Insert(yetenek);
        }
    }
}
