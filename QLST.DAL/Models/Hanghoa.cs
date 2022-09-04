using System;
using System.Collections.Generic;

#nullable disable

namespace QLST.DAL.Models
{
    public partial class Hanghoa
    {
        public int IdHh { get; set; }
        public string Tenhang { get; set; }
        public string Giahang { get; set; }
        public string Xuatxu { get; set; }
        public string Mota { get; set; }
        public int? Soluong { get; set; }
    }
}
