using QLST.Common.BLL;
using QLST.Common.Rsp;
using QLST.DAL;
using QLST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLST.BLL
{
    public class ProductService: GenericSvc<ProductRep,Hanghoa>
    {
        private ProductRep productRep;
        public ProductService()
        {
            productRep = new ProductRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
    }
}
