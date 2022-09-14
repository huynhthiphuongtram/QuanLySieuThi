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
    public class ProductService: GenericSvc<ProductRep,Hanghoa>
    {
        private ProductRep productRep;

        #region -- Overrides --
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
        #endregion

        #region -- Methods --
        public SingleRsp CreateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Hanghoa hanghoa = new Hanghoa();
            hanghoa.IdHh = productReq.IdHh;
            hanghoa.Tenhang = productReq.Tenhang;
            hanghoa.Giahang = productReq.Giahang;
            hanghoa.Soluong = productReq.Soluong;
            hanghoa.Xuatxu = productReq.Xuatxu;
            hanghoa.Mota = productReq.Mota;
            res = _rep.CreateProduct(hanghoa);
            return res;
        }
        public SingleRsp UpdateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Hanghoa hanghoa = new Hanghoa();
            hanghoa.IdHh = productReq.IdHh;
            hanghoa.Tenhang = productReq.Tenhang;
            hanghoa.Giahang = productReq.Giahang;
            hanghoa.Soluong = productReq.Soluong;
            hanghoa.Xuatxu = productReq.Xuatxu;
            hanghoa.Mota = productReq.Mota;
            res = _rep.UpdateProduct(hanghoa);
            return res;
        }
        public SingleRsp SearchProduct(SearchProductReq s)
        {
            var res = new SingleRsp();
            //lấy danh sách sản phẩm theo từ khóa
            var products = productRep.SearchProduct(s.Keyword);
            //xử lý phân trang
            int productCount, totalPages,offset; //offset: số bắt đầu
            offset = s.PageSize * (s.Page - 1);
            productCount = products.Count;
            totalPages = (productCount%s.PageSize)==0? productCount / s.PageSize: 1 + (productCount / s.PageSize);
            var obj =  new
            {
                Data = products.Skip(offset).Take(s.PageSize).ToList(),
                Page = s.Page,
                Size = s.PageSize
            };
            res.Data = obj;
            return res;
        }
        //public SingleRsp CheckExists(CheckProductExistsReq c)
        //{
        //    var res = new SingleRsp();
        //    Hanghoa hanghoa = new Hanghoa();
        //    res = _rep.All.Where(s => s.Giahang.Value(50000));
        //    return res;
        //}
        #endregion
    }
}
