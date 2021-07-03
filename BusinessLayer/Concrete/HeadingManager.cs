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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _HeadingDal;

        public HeadingManager(IHeadingDal HeadingDal)
        {
            _HeadingDal = HeadingDal;
        }

        public Heading GetByID(int id)
        {
            return _HeadingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _HeadingDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _HeadingDal.List(x => x.WriterID == id);
        }

        public void HeadingAdd(Heading heading)
        {
            _HeadingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _HeadingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _HeadingDal.Update(heading);
        }
    }
}
