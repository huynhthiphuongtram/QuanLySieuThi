using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLST.BLL;
using QLST.Common.Req;
using QLST.Common.Rsp;
using QLST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLST.DAL.Models;

namespace QLST.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }
        [HttpPost("get-by-id")]
        public IActionResult GetProductByID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productService.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpGet("get-all-product")]
        public IActionResult GetAllProduct()
        {
            var res = new SingleRsp();
            res.Data = productService.All;
            return Ok(res);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromForm] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productService.CreateProduct(productReq);
            return Ok(res);
        }

        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromForm] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            res = productService.SearchProduct(searchProductReq);
            return Ok(res);
        }

        [HttpPut("update-product")]
        public IActionResult UpdateProduct([FromForm] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productService.UpdateProduct(productReq);
            return Ok(res);
        }

        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct(int id)
        {
            dbblContext context = new dbblContext();
            var res = productService.Read(id);
            context.Remove(res.Data);
            context.SaveChanges();
            return Ok(res);
        }
    }
}
