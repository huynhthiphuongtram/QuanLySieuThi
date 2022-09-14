using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLST.BLL;
using QLST.Common.Req;
using QLST.Common.Rsp;
using QLST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLST.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserSvc userSvc;

        public UserController()
        {
            userSvc = new UserSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getUserById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = userSvc.Read(req.Id);
            return Ok(res);
        }

        [HttpGet("get-all-user")]
        public IActionResult GetAllUser()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All;
            return Ok(res);
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.CreateUser(userReq);
            return Ok(res);
        }

        [HttpPut("update-user")]
        public IActionResult UpdateUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.UpdateUser(userReq);
            return Ok(res);
        }

        [HttpDelete("delete-user")]
        public IActionResult DeleteUser(int id)
        {
            dbblContext context = new dbblContext();
            var res = userSvc.Read(id);
            context.Remove(res.Data);
            context.SaveChanges();
            return Ok(res);
        }
    }
}
