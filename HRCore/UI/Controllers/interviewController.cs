using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace UI.Controllers
{
    public class interviewController : Controller
    {
        private readonly IEngage_resumeBLL1 Resume;
        private readonly IEngage_interviewBLL1 inter;
        private readonly IUsersBLL1 user;
        public interviewController(IEngage_resumeBLL1 Resume, IEngage_interviewBLL1 inter, IUsersBLL1 user)
        {
            this.Resume = Resume;
            this.inter = inter;
            this.user = user;
        }
        public void xiala()
        {
            ViewBag.hard_value = new List<SelectListItem>() {
                new SelectListItem(){Value="A",Text="A"},
                new SelectListItem(){Value="B",Text="B"},
                 new SelectListItem(){Value="C",Text="C"},
            };
        }
        public void users()
        {
            List<Users_Model> list = user.Login();
            SelectList list2 = new SelectList(list, "U_id", "U_name");
            ViewData["sa"] = list2;
        }
        [HttpGet]
        public IActionResult interview_list()
        {

            return View();
        }
        [HttpPost]

        public IActionResult interview_list(FenYeModel fen)
        {
            //string major_kind_name = HttpContext.Session.GetString("major_kind_name");
            //string major_name = HttpContext.Session.GetString("major_name");
            //string startDate = HttpContext.Session.GetString("sd");
            //string endDate = HttpContext.Session.GetString("sb");
            //string name = HttpContext.Session.GetString("sa");
            //1fenYe.Where = " Check_status=1 and Standard_id like '%" + standardId + "%' and Designer like '%" + primarKey + "%' and Regist_time > '" + date_start + "' and Regist_time < '" + dateTime + "' ";
            
            
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            
            fen.Where = "";
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
        public async Task<IActionResult> interview_register()
        {
            xiala();
            users();

            int Res_id = Convert.ToInt32(Request.Query["Res_id"]);
            HttpContext.Session.SetString("resid",Res_id.ToString());
            //List<Engage_resume_Model> erm = Resume.ResumeUpSelect().Where(e => e.Res_id == Res_id).ToList();

            ViewBag.Ms = "第一次面试";
            ViewData.Model = await Resume.SelectResume(Res_id);
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> interview_register(Engage_resume_Model abc)
        {
         
                Engage_interview_Model em = new Engage_interview_Model();
                string a = Request.Form["a.Register"];
                List<Users_Model> um = new List<Users_Model>();
                um = user.SeledctUser(Convert.ToInt32(a));
                em.Register = um[0].U_name;
                em.Human_name = abc.Human_name;
                em.Human_major_kind_id = abc.Human_major_kind_id;
                em.Human_major_kind_name = abc.Human_major_kind_name;
                em.Human_major_id = abc.Human_major_id;
                em.Human_major_name = abc.Human_major_name;
                em.Interview_amount = 1;
                em.Image_degree = abc.Engage_Interview_Model.Image_degree;
                em.Native_language_degree = abc.Engage_Interview_Model.Native_language_degree;
                em.Foreign_language_degree = abc.Engage_Interview_Model.Foreign_language_degree;
                em.Response_speed_degree = abc.Engage_Interview_Model.Response_speed_degree;
                em.EQ_degree = abc.Engage_Interview_Model.Response_speed_degree;
                em.IQ_degree = abc.Engage_Interview_Model.IQ_degree;
                em.Multi_quality_degree = abc.Engage_Interview_Model.Multi_quality_degree;
                em.Interview_comment = abc.Engage_Interview_Model.Interview_comment;
            em.Registe_time =Convert.ToDateTime(Request.Form["engageInterview.registeTime"]);
                em.Resume_id = abc.Res_id;
                em.Interview_status = 1;

                int id = Convert.ToInt32(HttpContext.Session.GetString("resid"));
                abc = new Engage_resume_Model()
                {
                    Res_id =id,
                    Interview_status=1
                };

                if (await inter.Add(em) > 0&& await Resume.ResumeUpdate2(abc)>0)
                {
                    return RedirectToAction("sift_list");
                }
                else
                {
                    return RedirectToAction("interview_register");
                }
            }
        [HttpGet]
         public IActionResult sift_list(int id)
        {
            users();
            //ViewData.Model = inter.Selectinterview(id);
            //Engage_interview_Model enn = inter.CfSelectBy(id);
            //enn.engage_Resume_Model = Resume.CfSelectBy(enn.Resume_id);
            
            return View();
        }
        [HttpPost]

        public IActionResult sift_list(FenYeModel fen)
        {
          
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;            
            fen.Where = "";
            fen.KeyName = "Ein_id";
            fen.TableName = "Engage_interview";
            List<Engage_interview_Model> page = inter.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpGet]
        public IActionResult interview_sift(string Human_name)
        {
            users();
            Human_name = Request.Query["Human_name"];
            List<Engage_resume_Model> list = Resume.ResumeUpSelect().Where(e=>e.Human_name== Human_name).ToList();
            List<Engage_interview_Model> list2 = inter.Selectinterview().Where(e => e.Human_name == Human_name).ToList();
            ViewTable table = new ViewTable()
            {
                engage_Interview_s= list2,
                engage_Resumes= list
            };
            return View(table);
        }
        [HttpPost]
        public async Task<IActionResult> interview_sift(Engage_resume_Model insd)
        {
            int id = Convert.ToInt32(Request.Form["item.Res_id"]);

            string ss = Request.Form["item.Pass_checkComment"];
            insd = new Engage_resume_Model
            { 
                    Res_id=id,
                    Pass_checkComment=ss,
        };
            if (await inter.Update(insd) > 0)
            {
                return RedirectToAction("sift_list");
            }
            else
            {
                return View("sift_list");
            }
        }
    }
 }
