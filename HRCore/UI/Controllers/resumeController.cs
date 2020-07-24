using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using IBLL;
using EFEntity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Controllers
{
    public class resumeController : Controller
    {
        private readonly IConfig_major_kindBLL Makind;
        private readonly IConfig_majorBLL Major;
        private readonly IUsersBLL user;
        private readonly IConfig_public_charBLL Char;
        private readonly IEngage_resumeBLL Resume;
        public resumeController(IConfig_major_kindBLL Makind,IConfig_majorBLL Major,IUsersBLL user, IConfig_public_charBLL Char, IEngage_resumeBLL Resume)
        {
            this.Makind = Makind;
            this.Major = Major;
            this.user = user;
            this.Char = Char;
            this.Resume = Resume;
        }

        //职位分类
        public ActionResult xiala1()
        {
            List<Config_major_kind_Model> list = Makind.SelectMakind();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //职位名称
        public ActionResult xiala2(string id)
        {
            string name = Request.Form["name"];
            HttpContext.Session.SetString("Major_kind_name", name);
            List<Config_major_Model> list = Major.SelectsMajor().Where(e => e.Major_kind_id == id).ToList();
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["Major_kind_name"] = list[0].Major_name;
            di["Major_id"] = list[0].Major_id;
            string a = JsonConvert.SerializeObject(di);
            return Json(a);
            //string id = Request.Query["id"];
            //List<Config_major_Model> list = Major.SelectsMajor().Where(e => e.Major_kind_id == id).ToList();
            //Engage_resume_Model engage_s = new Engage_resume_Model()
            //{
            //    Human_major_id = list[0].Major_id,
            //    Human_major_name = list[0].Major_name
            //};
          
        }
        public ActionResult xialaKong()
        {
            string name2 = Request.Form["name2"];
            HttpContext.Session.SetString("Human_major_name", name2);
            string a = JsonConvert.SerializeObject(name2);
            return Json(a);
        }
        private void xiala3()
        {
            ViewBag.a1 = new List<SelectListItem>() {

                new SelectListItem(){Value="校园招聘",Text="校园招聘"},
                new SelectListItem(){Value="社会招聘",Text="社会招聘"}

            };

        }
        private void xiala4()
        {
            ViewBag.a2 = new List<SelectListItem>() {

                new SelectListItem(){Value="男",Text="男"},
                new SelectListItem(){Value="女",Text="女"}

            };
        }
        public void xiala5()
        {

            List<Users_Model> list = user.Login();
            SelectList list2 = new SelectList(list, "U_id", "U_name");
            ViewData["o"] = list2;
        }
        public void xiala6()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "国籍").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa6"] = list2;
        }
        public void xiala7()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "民族").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa7"] = list2;
        }
        public void xiala8()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "宗教信仰").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa8"] = list2;
        }
        public void xiala9()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "政治面貌").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa9"] = list2;
        }
        public void xiala10()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "学历").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa10"] = list2;
        }
        public void xiala11()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "教育年限").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa11"] = list2;
        }
        public void xiala12()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "专业").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa12"] = list2;
        }
        public void xiala13()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "特长").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa13"] = list2;
        }
        public void xiala14()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "爱好").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa14"] = list2;
        }
        [HttpGet]
        public IActionResult resume_register()
        {
            xiala1();
            
            xiala3();
            xiala4();  
            xiala5();
            xiala6();
            xiala7();
            xiala8();
            xiala9();
            xiala10();
            xiala11();
            xiala12();
            xiala13();
            xiala14();
            ViewBag.UName = HttpContext.Session.GetString("UName");
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> resume_register(Engage_resume_Model erm)
        {
            //Config_major_kind_Model c = new Config_major_kind_Model()
            //{
            //    Major_kind_id=erm.Human_major_kind_id
            //};
            //List<Config_major_kind_Model> list2 = Makind.SelectMakind().Where(e => e.Major_kind_id == c.Major_kind_id).ToList();
            //erm.Human_major_kind_name = list2[0].Major_kind_name;
            //Config_major_Model c1 = new Config_major_Model()
            //{
            //   Major_id=erm.Human_major_id
            //};
            //List<Config_major_Model> list3 = Major.SelectsMajor().Where(e => e.Major_id == c1.Major_id).ToList();

            //erm.Human_major_name = list3[0].Major_name;
            erm.Human_major_kind_name = HttpContext.Session.GetString("Major_kind_name");
            erm.Human_major_kind_id= Request.Form["major_kind"];
            erm.Human_major_id = Request.Form["Major_id"];
            erm.Human_major_name= Request.Form["Major_kind_name"];
            erm.Register = Request.Form["Register"];
            if (await Resume.Add(erm) > 0)
            {

        
                return RedirectToAction("resume_choose");
            }
            else
            {
                xiala6();
                xiala7();
                return View();
                //return RedirectToAction("position_register");
            }
        }

        public IActionResult resume_choose1()
        {
            
            List<Config_major_kind_Model> list = Makind.SelectMakind();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult resume_choose2(string id)
        {
            string name = Request.Form["name"];
            List<Config_major_Model> list = Major.SelectsMajor().Where(e => e.Major_kind_name == name).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public ActionResult resume_choose3()
        {
            string name2 = Request.Form["name2"];
            HttpContext.Session.SetString("Human_major_name", name2);
            string a = JsonConvert.SerializeObject(name2);
            return Json(a);
        }
        [HttpGet]
        public IActionResult resume_choose()
        {
               resume_choose1();          
                return View();
        }
        [HttpPost]
        public IActionResult resume_choose(Engage_resume_Model erm)
        {
            string major_kind_name = Request.Form["major_kind_id"];
            string major_name = Request.Form["major_id"];
            HttpContext.Session.SetString("major_name", major_name);
            HttpContext.Session.SetString("major_kind_name", major_kind_name);
            string sd = Request.Form["utilBean.startDate"];
            HttpContext.Session.SetString("startDate", sd);

            string sb = Request.Form["utilBean.endDate"];
            HttpContext.Session.SetString("endDate", sb);

            string sa = Request.Form["utilBean.primarKey"];
            HttpContext.Session.SetString("Human_name", sa);
            return RedirectToAction("resume_list");
           
        }

        [HttpGet]
        public IActionResult resume_list()
        {
            return View();
        }
        [HttpPost]

        public IActionResult resume_list(FenYeModel fen)
        {            
            string major_kind_name = HttpContext.Session.GetString("major_kind_name");
            string major_name = HttpContext.Session.GetString("major_name");
            string startDate = HttpContext.Session.GetString("startDate");
            string endDate = HttpContext.Session.GetString("endDate");
            string name = HttpContext.Session.GetString("Human_name");
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            //1fenYe.Where = " Check_status=1 and Standard_id like '%" + standardId + "%' and Designer like '%" + primarKey + "%' and Regist_time > '" + date_start + "' and Regist_time < '" + dateTime + "' ";
            fen.Where = $@" Human_name like'%" +name+ "%'and Human_major_kind_name like '%"+major_kind_name+ "%'and Human_major_name like '%" + major_name+ "%'and Regist_time>'" + startDate+ "'and Regist_time<'" + endDate+"'";
            fen.KeyName = "Res_id";
            fen.TableName = "Engage_resume";
            List<Engage_resume_Model> page = Resume.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));          
        }

        public IActionResult valid_resume1()
        {

            List<Config_major_kind_Model> list = Makind.SelectMakind();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult valid_resume2(string id)
        {
            string name = Request.Form["name"];
            List<Config_major_Model> list = Major.SelectsMajor().Where(e => e.Major_kind_name == name).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public ActionResult valid_resume3()
        {
            string name2 = Request.Form["name2"];
            HttpContext.Session.SetString("Human_major_name", name2);
            string a = JsonConvert.SerializeObject(name2);
            return Json(a);
        }
        [HttpGet]
        public IActionResult valid_resume()
        {
            valid_resume1();
            return View();
        }
        [HttpPost]
        public IActionResult valid_resume(Engage_resume_Model erm)
        {
            string major_kind_name = Request.Form["major_kind_id"];
            string major_name = Request.Form["major_id"];
            string sd = Request.Form["utilBean.startDate"];
            string sb = Request.Form["utilBean.endDate"];
            string sa = Request.Form["utilBean.primarKey"];
            if (major_name!=""|| major_kind_name!="")
            {
                HttpContext.Session.SetString("major_name", major_name);
                HttpContext.Session.SetString("major_kind_name", major_kind_name);
                HttpContext.Session.SetString("startDate", sd);
                HttpContext.Session.SetString("endDate", sb);
                HttpContext.Session.SetString("Human_name", sa);
                return RedirectToAction("valid_list");
            }
            else
            {
                return RedirectToAction("valid_resume");
            }

        }
        [HttpGet]
        public IActionResult valid_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult valid_list(FenYeModel fen)
        {
            string major_kind_name = HttpContext.Session.GetString("major_kind_name");
            string major_name = HttpContext.Session.GetString("major_name");
            string startDate = HttpContext.Session.GetString("startDate");
            string endDate = HttpContext.Session.GetString("endDate");
            string name = HttpContext.Session.GetString("Human_name");
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            //1fenYe.Where = " Check_status=1 and Standard_id like '%" + standardId + "%' and Designer like '%" + primarKey + "%' and Regist_time > '" + date_start + "' and Regist_time < '" + dateTime + "' ";
            fen.Where = $@" Human_name like'%" + name + "%'and Human_major_kind_name like '%" + major_kind_name + "%'and Human_major_name like '%" + major_name + "%'and Regist_time>'" + startDate + "'and Regist_time<'" + endDate + "'";
            fen.KeyName = "Res_id";
            fen.TableName = "Engage_resume";
            List<Engage_resume_Model> page = Resume.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpGet]
        public IActionResult resume_details()
        {
            int Res_id =Convert.ToInt32(Request.Query["Resid"]);
            List<Engage_resume_Model> erm = Resume.ResumeUpSelect().Where(e => e.Res_id == Res_id).ToList(); 
            ViewTable table = new ViewTable() 
            {
                engage_Resumes=erm
            };
            xiala5();
            ViewBag.UName = HttpContext.Session.GetString("UName");
            return View(table);
        }

        [HttpPost]
        public async Task<IActionResult> resume_details(Engage_resume_Model erm)
        {
            erm = new Engage_resume_Model()
            {
                Checker = Request.Form["item.Checker"],
                Check_time = Convert.ToDateTime(Request.Form["item.Check_time"]),
                Recomandation = Request.Form["item.Recomandation"],
                Check_status = 1,
                Res_id = Convert.ToInt32(Request.Form["item.Res_id"])
             };
            int result =await Resume.ResumeUpdate(erm);
            if (result>0)
            {
                return RedirectToAction("valid_resume");
            }
            else
            {
                return View(erm);
            }
        }
        public IActionResult Resume_select() 
        {
            int Res_id = Convert.ToInt32(Request.Query["Rid"]);
            List<Engage_resume_Model> erm = Resume.ResumeUpSelect().Where(e => e.Res_id == Res_id).ToList();
            ViewTable table = new ViewTable()
            {
                engage_Resumes = erm
            };
            return View(table);
        }
    }
}