using QLBH.Common.Req;
using QLBH.DAL;
using QLST.Common.BLL;
using QLST.Common.Rsp;
using QLST.DAL;
using QLST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.BLL
{
    public class HoadonSvc : GenericSvc<HoadonRep, Hoadon>
    {
        private HoadonRep hoadonRep;
        private readonly ProductRep productRep;
     
        
        public HoadonSvc()
        {
            hoadonRep = new HoadonRep();
        }
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(Hoadon m)
        {
            var res = new SingleRsp();

            var m1 = m.Id > 0 ? _rep.Read(m.Id) : _rep.Read(m.Id);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        #endregion
        #region -- Methods --
        public SingleRsp Timhanghoadon(TimhanghoadonReq s)
        {
            var res = new SingleRsp();
            var hoadon = hoadonRep.Timhanghoadon(s.IdHoaDon);
           
            var obj = new
            {
                Data = hoadon
            };
            res.Data = obj;
            return res;
        }
        public SingleRsp Thanhtoan(HoadonReq hoadonReq)
        {
            var res = new SingleRsp();
            Hoadon hoadon = new Hoadon();
            hoadon.Id = hoadonReq.MaHoaDon;
            hoadon.IdNv = hoadonReq.MaNhanVien;
            //int y = hoadonReq.MaHangHoa;
            //int dongia = (int)hanghoaRep.LayhhbyId(y);
            hoadon.Thanhtien = 20000 * hoadonReq.SoLuong;
            //int dongia = (int)hanghoaRep.LayhhbyId(hoadonReq.MaHangHoa);
            //hoadon.Thanhtien = dongia * hoadonReq.SoLuong;
            //hoadon.Thanhtien = 400000;
            //ICollection<Chitiethoadon> chitiethoadons = new List<Chitiethoadon>();
            Chitiethoadon chitiethoadon = new Chitiethoadon();
            chitiethoadon.Id = hoadonReq.MaHoaDon;
            chitiethoadon.ChitietId = hoadonReq.MaHoaDon;
            chitiethoadon.HanghoaId = hoadonReq.MaHangHoa;
            chitiethoadon.Soluong = hoadonReq.SoLuong;
            //chitiethoadons.Add(chitiethoadon);
            //_ = hoadon.Chitiethoadons;
            res = hoadonRep.Thanhtoan(hoadon, chitiethoadon);
            return res;
            
        }
        public SingleRsp CapnhatHoaDon(HoadonReq hoadonReq)
        {
            var res = new SingleRsp();
            Hoadon hoadon = new Hoadon();
            hoadon.Id = hoadonReq.MaHoaDon;
            hoadon.IdNv = hoadonReq.MaNhanVien;
            hoadon.Thanhtien = 20000 * hoadonReq.SoLuong;
            //hoadon.Thanhtien = 400000;
            //ICollection<Chitiethoadon> chitiethoadons = new List<Chitiethoadon>();
            Chitiethoadon chitiethoadon = new Chitiethoadon();
            chitiethoadon.Id = hoadonReq.MaHoaDon;
            chitiethoadon.ChitietId = hoadonReq.MaHoaDon;
            chitiethoadon.HanghoaId = hoadonReq.MaHangHoa;
            chitiethoadon.Soluong = hoadonReq.SoLuong;
            //chitiethoadons.Add(chitiethoadon);
            //_ = hoadon.Chitiethoadons;
            res = hoadonRep.CapnhatHoaDon(hoadon, chitiethoadon);
            return res;


           
        }
        public SingleRsp XoaHoaDon(TimhanghoadonReq s)
        {
            var res = new SingleRsp();
            var hoadon = hoadonRep.Remove(s.IdHoaDon);

            var obj = new
            {
                Data = hoadon
            };
            res.Data = obj;
            return res;
        }
        #endregion

    }
}