using System;
using System.Collections.Generic;
using System.Text;

namespace QLST.Common.Req
{
    public class SearchUserReq
    {
        public String Keyword { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
