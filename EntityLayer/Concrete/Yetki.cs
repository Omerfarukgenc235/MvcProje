using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Yetki
    {
        [Key]
        public int RoleID { get; set; }
        [StringLength(1)]
        public string Role { get; set; }

        public ICollection<Admin> Admins { get; set; }
    }
}
