using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLST.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoadonController : ControllerBase
    {
        private HoadonSvc hoadonSvc;
        private ChitietHoadonSvc chitietHoadonSvc;
        public HoadonController()
        {
            hoadonSvc = new HoadonSvc();
        }

        [HttpPost("Thanhtoan")]
        public IActionResult Thanhtoan([FromBody] HoadonReq hoadonReq)
        {

            var res = new SingleRsp();
            var hoadon = hoadonSvc.Thanhtoan(hoadonReq);
            res.Data = hoadon;
            return Ok(res);
            
        }
        [HttpPost("SuaHoadon")]
        public IActionResult SuaHoadon([FromBody] HoadonReq hoadonReq)
        {

            var res = new SingleRsp();
            var hoadon = hoadonSvc.CapnhatHoaDon(hoadonReq);
            res.Data = hoadon;
            return Ok(res);

        }
        [HttpPost("XoaHoadon")]
        public IActionResult XoaHoadon([FromBody] TimhanghoadonReq timhanghoadonReq)
        {

            var res = new SingleRsp();
            var hoadon = hoadonSvc.XoaHoaDon(timhanghoadonReq);
            res.Data = hoadon;
            return Ok(res);

        }
        [HttpPost("timkiem-hoadon")]
        public IActionResult Timhanghoadon([FromBody] TimhanghoadonReq timhanghoaReq)
        {
            
            var res = new SingleRsp();
            res = hoadonSvc.Timhanghoadon(timhanghoaReq);

            return Ok(res);
        }
        
    }
}
