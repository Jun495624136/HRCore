using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace UI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsers_BLL usersbll;
        public UsersController(IUsers_BLL users_)
        {
            this.usersbll = users_;
        }

        //private readonly IWebHostEnvironment environment;

        //public UsersController(IWebHostEnvironment environment)
        //{
        //    this.environment = environment;
        //}
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users_Model users_)
        {
            if (ModelState.IsValid)
            {
                List<Users_Model> list = usersbll.Login().Where(e => e.U_name == users_.U_name && e.U_password == users_.U_password).ToList();
                if (list.Count > 0)
                {
                    HttpContext.Session.SetString("UName", list[0].U_name);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return View(users_);
            }

        }
        //public IActionResult Login(IFormFileCollection file)
        //{
        //    foreach (var item in file)
        //    {
        //        //生成文件名
        //        string name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //        //获取后缀名
        //        string ext = item.FileName.Substring(item.FileName.LastIndexOf('.'));
        //        //设置上传路径
        //        string path = $"Uploader/{DateTime.Now.ToString("yyyy/MM/dd/")}" + name + ext;
        //        //生成文件的绝对路径
        //        var uploads = Path.Combine(environment.WebRootPath, path);
        //        //创建上传文件对应的文件夹
        //        (new FileInfo(uploads)).Directory.Create();
        //        using (var stream = new FileStream(uploads, FileMode.CreateNew))
        //        {
        //            item.CopyTo(stream);//图片上传
        //            TempData["name"] = name + ext;//保存图片的值
        //        }
        //    }

        //    return View();
        //}
        public IActionResult Index()
        {
            ViewBag.Nmae= HttpContext.Session.GetString("UName");
            return View();
        }

    }
}