using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Model;
using IBLL;


namespace UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersBLL1 sa;
        public LoginController(IUsersBLL1 sa)
        {
            this.sa = sa;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users_Model us)
        {
           List<Users_Model> list = sa.Login().Where(e => e.U_name == us.U_name && e.U_password == us.U_password).ToList();
            if (list.Count > 0)
            {
                HttpContext.Session.SetString("UName", list[0].U_name);
                return RedirectToAction("left");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public IActionResult left()
        {
            return View();
        }
    }
}