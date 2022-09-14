using QLST.Common.BLL;
using QLST.Common.Req;
using QLST.Common.Rsp;
using QLST.DAL;
using QLST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLST.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        public object SearchUser(SearchUserReq s)
        {
            //Lấy danh sách user theo từ khóa
            List<User> users = _rep.SearchUser(s.Keyword);
            //Xư lý phân trang
            var offset = (s.Page - 1) * s.Size; //Thứ tự bắt đầu mỗi trang
            var total = users.Count; //Tổng người dùng
            int totalPage = (total % s.Size) == 0 ? (int)(total / s.Size) :
                (int)(1 + (total / s.Size));

            var data = users.Skip(offset).Take(s.Size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPage,
                Page = s.Page,
                Size = s.Size

            };
            return res;
        }
        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.Username = userReq.Username;
            user.Password = userReq.Password;
            user.Role = userReq.Role;
            res = _rep.CreateUser(user);
            return res;
        }

        public SingleRsp UpdateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.Username = userReq.Username;
            user.Password = userReq.Password;
            user.Role = userReq.Role;
            res = _rep.UpdateUser(user);
            return res;
        }
    }
}
