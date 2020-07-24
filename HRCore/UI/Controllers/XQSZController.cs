using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using EFEntity;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
    public class XQSZController : Controller
    {
        private readonly JueSeIBLL JSbl;
        private readonly YHquanxianIBLL YH;
        private readonly HR_DBContext tesc;
        public XQSZController(JueSeIBLL JSbl, YHquanxianIBLL YH, HR_DBContext tesc)
        {
            this.YH = YH;
            this.JSbl = JSbl;
            this.tesc = tesc;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult check_list(int id) {
            DBFenYe<JueSeModel> li = JSbl.Fenye(id, "JueSe", " ", "JueSe_id", 3);
            return Content(JsonConvert.SerializeObject(li)); ;
        }
        public IActionResult user_add() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> user_add1()
        {
            string JSMC = HttpContext.Request.Form["sysRole.roleName"];
            string SFKY = HttpContext.Request.Form["sysRole.roleFlag"];
            JueSeModel a = new JueSeModel() { JueSe_name=JSMC, SFky=Convert.ToInt32(SFKY) };
            if (ModelState.IsValid)
            {
                if (await JSbl.ADD(a) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("user_add");
                }
            }
            else
            {
                return RedirectToAction("user_add");
            }
       
        }
        public async Task<int> Del(int id)
        {
            if (await JSbl.Delete(id) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public async Task<IActionResult> js_edit(int id) 
        {
            JueSeModel A = await JSbl.select(id);
            ViewData.Model = A;
            return View();
        }
        public IActionResult fxk(int? id) 
        {
            string aa = HttpContext.Session.GetString("XGJSID");
            string sql = "";
            if (id == null)
            {
                sql = $@"select q.[id],[text],[state],[JUid],[URL],checked=
case 
when qr.id is null then 0
else 1
end
from dbo.SFquanxian
        q
left join(
select id
from  dbo.YHquanxian
where JueSe_id={aa}
) qr on q.id=qr.id
where q.JUid=0
";
            }
            else
            {
                sql = $@"select q.[id],[text],[state],[JUid],[URL],checked=
case 
when qr.id is null then 0
else 1
end
from dbo.SFquanxian
        q
left join(
select id
from  dbo.YHquanxian
where JueSe_id={aa}
) qr on q.id=qr.id
where q.JUid={id}
";
            }
            List<ljsb> list = tesc.ljsb.FromSqlRaw(sql).ToList();
            return Ok(list);
        }
        public async Task<IActionResult> xxxx(int id) {
            HttpContext.Session.SetString("XGJSID", id.ToString());
            JueSeModel A = await JSbl.select(id);
            ViewData.Model = A;
            return View();
        }
        [HttpPost]
        public IActionResult XG(string dt) {
            String[] arr = dt.Split(",");
            string sql = $@"delete dbo.YHquanxian where JueSe_id={HttpContext.Session.GetString("XGJSID")}";
            int aa = tesc.Database.ExecuteSqlCommand(sql);
            int a = 0;
            string sql1 = "";
            for (int i = 0; i < arr.Length; i++)
            {
                sql1 = $@"insert into dbo.YHquanxian VALUES({HttpContext.Session.GetString("XGJSID")},{arr[i]})";
                a = tesc.Database.ExecuteSqlCommand(sql1);
            }
            if (a > 0)
            {
                return Ok(a);
            }
            else {
                return Ok(a);
            }
        }
    }
}