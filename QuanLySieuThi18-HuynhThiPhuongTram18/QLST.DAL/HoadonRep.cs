using Microsoft.EntityFrameworkCore;
using QLST.Common.DAL;
using QLST.Common.Rsp;
using QLST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class HoadonRep : GenericRep<dbblContext, Hoadon>
    {
        #region -- Overrides --
        public override Hoadon Read(int id)
        {
            var res = All.FirstOrDefault(p => p.Id == id);
            return res;
        }


        public int Remove(int id)
        {
            var m = base.All.First(i => i.Id == id);
            m = base.Delete(m);
            return m.Id;
        }


        #endregion



        #region -- Methods --
        public SingleRsp Thanhtoan(Hoadon hoadon, Chitiethoadon chitiethoadon)
        {
            var res = new SingleRsp();
            using (var context = new dbblContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Hoadons.AddRangeAsync(hoadon);
                        context.SaveChanges();
                        var s = context.Chitiethoadons.AddRangeAsync(chitiethoadon);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp Timhanghoadon(int tukhoa)
        {
            var res = new SingleRsp();

            res.Data = All.Where(x => x.Id == tukhoa);

            return res;
        }
        public SingleRsp CapnhatHoaDon(Hoadon hoadon, Chitiethoadon chitiethoadon)
        {
            var res = new SingleRsp();
            using (var context = new dbblContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Hoadons.Update(hoadon);
                        context.SaveChanges();
                        var s = context.Chitiethoadons.Update(chitiethoadon);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp XoaHoaDon(int id)
        {
            var res = new SingleRsp();
            using (var context = new dbblContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = All.FirstOrDefault(x => x.Id == id);
                        context.Remove(m);
                        base.Delete(m);
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;

        }

        #endregion

    }
}
