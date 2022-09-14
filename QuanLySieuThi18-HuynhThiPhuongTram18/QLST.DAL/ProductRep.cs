using QLST.Common.DAL;
using QLST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QLST.Common.Rsp;

namespace QLST.DAL
{
    public class ProductRep:GenericRep<dbblContext,Hanghoa>
    {
        #region -- Overrides --
        public override Hanghoa Read(int id)
        {
            var res = All.FirstOrDefault(p => p.IdHh == id);
            return res;
        }

        public int Remove(int id)
        {
            var r = base.All.First(i => i.IdHh == id);
            r = base.Delete(r);
            return r.IdHh;
        }

        #endregion

        #region -- Methods --
        public SingleRsp CreateProduct(Hanghoa hanghoa)
        {
            var res = new SingleRsp();
            using (var context = new dbblContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Hanghoas.Add(hanghoa);
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
        public SingleRsp UpdateProduct(Hanghoa hanghoa)
        {
            var res = new SingleRsp();
            using (var context = new dbblContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Hanghoas.Update(hanghoa);
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
        public List<Hanghoa> SearchProduct(string keyWord)
        {
            return All.Where(x => x.Tenhang.Contains(keyWord)).ToList();
        }

        #endregion
    }
}
