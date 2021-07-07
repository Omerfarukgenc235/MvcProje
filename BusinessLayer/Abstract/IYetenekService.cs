using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IYetenekService
    {
        void YetenekAdd(Yetenek yetenek);
        List<Yetenek> GetYeteneks();
        void Update(Yetenek yetenek);
        void Delete(Yetenek yetenek);
    }
}
