using QLST.Common.DAL;
using QLST.Common.Rsp;
using QLST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLST.DAL
{
    public class UserRep : GenericRep<dbblContext, User>
    {
        //Tìm người dùng bằng Id
        #region -- Overrides --
        public override User Read(int id)
        {
            var res = All.FirstOrDefault(p => p.UserId == id);
            return res;
        }
        #endregion



        //Tìm người dùng theo từ khóa
        public List<User> SearchUser(string KeyWord)
        {
            return All.Where(x => x.Username.Contains(KeyWord)).ToList();
        }

        //Thêm người dùng
        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new dbblContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Add(user);
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

        //Sửa thông tin người dùng
        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new dbblContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Update(user);
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
    }
}
