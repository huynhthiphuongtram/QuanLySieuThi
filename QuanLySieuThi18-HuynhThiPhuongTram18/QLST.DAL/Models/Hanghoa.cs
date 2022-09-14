using System;
using System.Collections.Generic;

#nullable disable

namespace QLST.DAL.Models
{
    public partial class Hanghoa
    {
        public Hanghoa()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
        }

        public int IdHh { get; set; }
        public string Tenhang { get; set; }
        public int? Giahang { get; set; }
        public string Xuatxu { get; set; }
        public string Mota { get; set; }
        public int? Soluong { get; set; }

        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
    }
}
