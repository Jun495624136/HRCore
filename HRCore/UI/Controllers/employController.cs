using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using EFEntity;
using IBLL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Controllers
{
    public class employController : Controller
    {
        private readonly IEngage_resumeBLL Resume;
        private readonly IUsersBLL user;
        private readonly IEngage_interviewBLL inter;
        public employController(IEngage_resumeBLL Resume,IUsersBLL user,IEngage_interviewBLL inter)
        {
            this.Resume = Resume;
            this.user = user;
            this.inter = inter;
        }
        public void users()
        {
            List<Users_Model> list = user.Login();
            SelectList list2 = new SelectList(list, "U_id", "U_name");
            ViewData["sa"] = list2;
        }
        [HttpGet]
        public IActionResult register_list()
        {
            return View();
        }
        [HttpPost]

        public IActionResult register_list(FenYeModel fen)
        {

            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = "Interview_status=1";
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
        public IActionResult register(string Human_name)
        {
            users();
            Human_name = Request.Query["Human_name"];
            List<Engage_resume_Model> list = Resume.ResumeUpSelect().Where(e => e.Human_name == Human_name).ToList();
            List<Engage_interview_Model> list2 = inter.Selectinterview().Where(e => e.Human_name == Human_name).ToList();
            ViewTable table = new ViewTable()
            {
                engage_Interview_s = list2,
                engage_Resumes = list
            };
            ViewBag.Ms = "第一次面试";
            return View(table);
        }
        [HttpPost]
        public async Task<IActionResult> register(Engage_resume_Model erm)
        {
            int id = Convert.ToInt32(Request.Form["item.Res_id"]);

            string ss = Request.Form["item.Pass_checkComment"];
            erm = new Engage_resume_Model
            {
               Res_id=id,
               Pass_checkComment=ss
                
            };
            if (await inter.Update(erm) > 0)
            {
                return RedirectToAction("register_list");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult check_list()
        {
            return View();
        }

        [HttpPost]

        public IActionResult check_list(FenYeModel fen)
        {

            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = "Interview_status=1";
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
        public IActionResult check(string Human_name)
        {
            users();
            Human_name = Request.Query["Human_name"];
            List<Engage_resume_Model> list = Resume.ResumeUpSelect().Where(e => e.Human_name == Human_name).ToList();
            List<Engage_interview_Model> list2 = inter.Selectinterview().Where(e => e.Human_name == Human_name).ToList();
            ViewTable table = new ViewTable()
            {
                engage_Interview_s = list2,
                engage_Resumes = list
            };
            ViewBag.Ms = "第一次面试";
            return View(table);
        }
        [HttpPost]
        public async Task<IActionResult> check(Engage_resume_Model erm)
        {
            int id = Convert.ToInt32(Request.Form["item.Res_id"]);
            string sa = Request.Form["item.Pass_passComment"];
            string ss = Request.Form["item.Pass_checkComment"];
            erm = new Engage_resume_Model
            {
                Pass_passComment=sa,
                Res_id = id,
                Pass_checkComment = ss

            };
            if (await inter.Update(erm) > 0)
            {
                return RedirectToAction("check_list");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult list()
        {
            return View();
        }
        [HttpPost]

        public IActionResult list(FenYeModel fen)
        {

            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = "Interview_status=1";
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
        public IActionResult details(string Human_name)
        {
            users();
            Human_name = Request.Query["Human_name"];
            List<Engage_resume_Model> list = Resume.ResumeUpSelect().Where(e => e.Human_name == Human_name).ToList();
            List<Engage_interview_Model> list2 = inter.Selectinterview().Where(e => e.Human_name == Human_name).ToList();
            ViewTable table = new ViewTable()
            {
                engage_Interview_s = list2,
                engage_Resumes = list
            };
            return View(table);
        }
    }
}