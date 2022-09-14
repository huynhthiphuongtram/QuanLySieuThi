using System;
using System.Collections.Generic;

#nullable disable

namespace QLST.DAL.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
        }

        public int Id { get; set; }
        public int IdNv { get; set; }
        public int Thanhtien { get; set; }

        public virtual User IdNvNavigation { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
    }
}
