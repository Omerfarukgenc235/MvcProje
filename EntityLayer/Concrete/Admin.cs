using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public byte[] AdminUserName { get; set; }
        public byte[] AdminPasswordHash { get; set; }
        public byte[] AdminPasswordSalt { get; set; }
        public bool AdminDurum { get; set; }
        public int AdminYetkiID { get; set; }
        public virtual Yetki Yetkis { get; set; }

    }
}
