using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Yetenek
    {
        [Key]
        public int YetenekID { get; set; }
        [StringLength(50)]
        public String YetenekAdi { get; set; }
        public int Yetenekyuzde { get; set; }
        public bool YetenekDurum { get; set; }
    }
}
