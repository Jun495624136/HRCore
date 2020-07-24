using System.Threading.Tasks;
using Model;
using IBLL;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsers_BLL ubll;
        public LoginController(IUsers_BLL ubll)
        {
            this.ubll = ubll;
        }
        
        [HttpGet]
        public IActionResult Login([FromQuery]Users_Model u)
        {
            List<Users_Model> list = ubll.Login().Where(e => e.U_name == u.U_name && e.U_password == u.U_password).ToList();
            //List<Users_Model> list = ubll.Login().ToList();
            HttpContext.Session.SetString("UName", list[0].U_name);
            return Ok(list);
            //return Content(c.ToString());
        }
    }
}