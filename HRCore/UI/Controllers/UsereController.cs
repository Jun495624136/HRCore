using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using IBLL;
using Microsoft.AspNetCore.Http;
using EFEntity;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
    public class UsereController : Controller
    {
        private readonly UsersIBLL coreDbContext;
        private readonly HR_DBContext tesc;
        private readonly JueSeIBLL js;
        public UsereController(UsersIBLL coreDbContext, HR_DBContext tesc, JueSeIBLL js)
        {
            this.coreDbContext = coreDbContext;
            this.tesc = tesc;
            this.js = js;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Index(Users_Model um)
            {
              
                int reslut = await coreDbContext.Login(um);
                    if (reslut > 0)
                    {
                       string name = coreDbContext.js(um);
                       HttpContext.Session.SetString("Uname", um.U_name);
                        List<JueSeModel> aa = await js.RoleSelect();
                        foreach (JueSeModel item in aa)
                        {
                            if (item.JueSe_name ==name)
                            {
                                HttpContext.Session.SetString("JSID", item.JueSe_id.ToString());
                            }
                        }
                return Redirect("/Usere/left");
            }
            else
                    {
                        return Content("<script>alert('登录失败');</script>");
                    }
            }
        public IActionResult left()
        {
            if (HttpContext.Session.GetString("Uname") != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Usere/Index");
            }
        }
        public IActionResult top()
        {
            return View();
        }
        public IActionResult indexff(int? id)
        {
            string aa = HttpContext.Session.GetString("JSID");
            string sql = "";
            if (id == null)
            {
                sql = $@"select q.id,[text],URL,[state],JUid from dbo.SFquanxian q inner join dbo.YHquanxian qr on q.id=qr.id
where qr.JueSe_id={aa} and q.JUid=0";

            }
            else
            {
                sql = $@"select q.id,[text],URL,[state],JUid from dbo.SFquanxian q inner join dbo.YHquanxian qr on q.id=qr.id
where qr.JueSe_id={aa} and q.JUid={id}";
            }
            //增删改sql myDbContext.Database.ExecuteSqlCommand()

            List<SFquanxian> list = tesc.SFquanxians.FromSqlRaw(sql).ToList();
            return Ok(list);
        }
    }
}