using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using IBLL;
using IDAO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class DDCXController : Controller
    {
        private readonly Major_changeIBLL HF;
        public DDCXController(Major_changeIBLL HF) 
        {
            this.HF = HF;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            HttpContext.Session.SetString("fristname", HttpContext.Request.Form["configThird.firstKindId"]);
            HttpContext.Session.SetString("senconname", HttpContext.Request.Form["configThird.secondKindId"]);
            HttpContext.Session.SetString("thirdname", HttpContext.Request.Form["configThird.thirdKindId"]);
            HttpContext.Session.SetString("starttime", HttpContext.Request.Form["utilbean.startDate"]);
            HttpContext.Session.SetString("endtime", HttpContext.Request.Form["utilbean.endDate"]);
            HttpContext.Session.SetString("mk", HttpContext.Request.Form["emajorRelease.Major_kindId"]);
            HttpContext.Session.SetString("m", HttpContext.Request.Form["emajorRelease.Major_Id"]);
            return RedirectToAction("select");
        }
        public IActionResult select() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult select(int id)
        {
            //a.Regist_time >= ktime && a.Regist_time <= endtime
            string fristname = HttpContext.Session.GetString("fristname").ToString();
            string senconname = HttpContext.Session.GetString("senconname").ToString();
            string thirdname = HttpContext.Session.GetString("thirdname").ToString();
            string mk = HttpContext.Session.GetString("mk").ToString();
            string m = HttpContext.Session.GetString("m").ToString();
            DateTime starttime = Convert.ToDateTime(HttpContext.Session.GetString("starttime"));
            DateTime endtime = Convert.ToDateTime(HttpContext.Session.GetString("endtime"));
            if (fristname == "")
            {
                return RedirectToAction("index");
            }
            else
            {
                if (fristname != "" && senconname == "请选择二级机构" && thirdname == "请选择三级机构")
                {
                    senconname = "";
                    thirdname = "";
                }
                else if (fristname != "" && senconname != "" && thirdname == "请选择三级机构")
                {
                    thirdname = "";
                }
                string where = $@" New_first_kind_id='{fristname}' and New_second_kind_id='{senconname}' and New_third_kind_id='{thirdname}' and New_major_kind_name='{mk}' and New_major_name='{m}' and Check_time<='{endtime}' and Check_time>='{starttime}'"; /*and Check_time>= '{starttime}'*/
                DBFenYe<Major_change_Model> li = HF.Fenye(id, "Major_change", where, "Mch_id", 3);
                return Content(JsonConvert.SerializeObject(li)); ;
            }
        }
        public async  Task<IActionResult> register(int id) 
        {
            Major_change_Model b = await HF.SelByID02(id);
            ViewData.Model = b;
            return View();
        }
    }
}