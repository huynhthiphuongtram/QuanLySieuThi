using System;
using System.Collections.Generic;
using System.Text;

namespace QLST.Common.Req
{
    public class UserReq
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
