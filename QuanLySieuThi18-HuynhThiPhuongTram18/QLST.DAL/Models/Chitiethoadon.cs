using System;
using System.Collections.Generic;

#nullable disable

namespace QLST.DAL.Models
{
    public partial class Chitiethoadon
    {
        public int Id { get; set; }
        public int ChitietId { get; set; }
        public int HanghoaId { get; set; }
        public int Soluong { get; set; }

        public virtual Hoadon Chitiet { get; set; }
        public virtual Hanghoa Hanghoa { get; set; }
    }
}
