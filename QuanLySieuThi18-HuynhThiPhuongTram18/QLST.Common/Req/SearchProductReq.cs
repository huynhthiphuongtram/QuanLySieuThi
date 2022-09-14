using System;
using System.Collections.Generic;
using System.Text;

namespace QLST.Common.Req
{
    public class SearchProductReq
    {
        public string Keyword { get; set; }
        public int Page { get; set; }
        public int PageSize{ get; set; }
    }
}
