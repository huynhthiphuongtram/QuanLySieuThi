using System;
using System.Collections.Generic;
using System.Text;

namespace QLST.Common.Req
{
    public class ProductReq
    {
        public int IdHh { get; set; }
        public string Tenhang { get; set; }
        public int? Giahang { get; set; }
        public string Xuatxu { get; set; }
        public string Mota { get; set; }
        public int? Soluong { get; set; }
    }
}
