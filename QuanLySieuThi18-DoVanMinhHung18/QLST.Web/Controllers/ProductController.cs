using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLST.BLL;
using QLST.Common.Req;
using QLST.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
