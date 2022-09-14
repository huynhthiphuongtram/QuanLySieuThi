using QLST.Common.DAL;
using QLST.Common.Rsp;
using QLST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class ChitietHoaDonRep : GenericRep<dbblContext, Chitiethoadon>
    {
        #region -- Overrides --
        public override Chitiethoadon Read(int id)
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
        public SingleRsp Themhoadon(Chitiethoadon chitiethoadon)
        {
            var res = new SingleRsp();
            using (var context = new dbblContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Chitiethoadons.Add(chitiethoadon);
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

        #endregion
    }
}
