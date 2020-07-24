using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using IBLL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace UI.Controllers
{
    public class DDSQController : Controller
    {
        private readonly Config_file_first_kindIBLL YJ;
        private readonly Config_file_second_kindIBLL EJ;
        private readonly config_file_third_kindIBLL SJ;
        private readonly Human_fileIBLL HF;
        private readonly config_major_kindIBLL cmk;
        private readonly Config_majorIBLL cm;
        private readonly Salary_standardModelIBLL ss;
        private readonly Major_changeIBLL mc;
        public DDSQController(Config_file_first_kindIBLL YJ, Config_file_second_kindIBLL EJ, config_file_third_kindIBLL SJ, Human_fileIBLL HF, config_major_kindIBLL cmk,Config_majorIBLL cm, Salary_standardModelIBLL ss, Major_changeIBLL mc)
        {
            this.YJ = YJ;
            this.EJ = EJ;
            this.SJ = SJ;
            this.HF = HF;
            this.cmk = cmk;
            this.cm = cm;
            this.ss = ss;
            this.mc = mc;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult first()
        {
            List<Config_file_first_kind_Model> list = YJ.YJselect();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult first1()
        {
            string f = HttpContext.Session.GetString("f").ToString();
            string s= HttpContext.Session.GetString("s").ToString();
            List<Config_file_first_kind_Model> list = YJ.YJselect();
            if (s == null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].First_kind_name == f)
                    {
                        list.Remove(list[i]);
                        break;
                    }
                }
            }
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult Selfirst(string id)
        {
            
            List<Config_file_second_kind_Model> list = EJ.EJselect().Where(e => e.First_kind_id == id).ToList();
          
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult Selfirst1(string id)
        {
            string s = HttpContext.Session.GetString("s").ToString();
            string t = HttpContext.Session.GetString("t").ToString();
            id = Request.Form["id"];
            List<Config_file_second_kind_Model> list = EJ.EJselect().Where(e => e.First_kind_name == id).ToList();
            if (t == null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Second_kind_name == s)
                    {
                        list.Remove(list[i]);
                        break;
                    }
                }
            }
           
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }

        public IActionResult ThiSecond(string id,string id2)
        {
            List<Config_file_third_kind_Model> list = SJ.SJselect().Where(e => e.Second_kind_id == id && e.First_kind_id == id2).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult ThiSecond1(string id, string id2)
        {
            string t = HttpContext.Session.GetString("t").ToString();
            List<Config_file_third_kind_Model> list = SJ.SJselect().Where(e => e.Second_kind_name == id && e.First_kind_name == id2).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Third_kind_name == t)
                {
                    list.Remove(list[i]);
                    break;
                }
            }
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        [HttpGet]
        public ActionResult select()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index1()
        {
            HttpContext.Session.SetString("fristname", HttpContext.Request.Form["configThird.firstKindId"]);
            HttpContext.Session.SetString("senconname", HttpContext.Request.Form["configThird.secondKindId"]);
            HttpContext.Session.SetString("thirdname", HttpContext.Request.Form["configThird.thirdKindId"]);
            HttpContext.Session.SetString("starttime", HttpContext.Request.Form["utilbean.startDate"]);
            HttpContext.Session.SetString("endtime", HttpContext.Request.Form["utilbean.endDate"]);
            return RedirectToAction("select");
        }
        [HttpPost]
        public ActionResult select(int id)
        {

            //a.Regist_time >= ktime && a.Regist_time <= endtime
            string fristname = HttpContext.Session.GetString("fristname").ToString();
            string senconname = HttpContext.Session.GetString("senconname").ToString();
            string thirdname = HttpContext.Session.GetString("thirdname").ToString();
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
                string where1=$@" First_kind_id='{fristname}' and Second_kind_id='{senconname}' and Third_kind_id='{thirdname}' and Regist_time>='{starttime}' and Regist_time<='{endtime}' and Check_status=1";
                DBFenYe<Human_file_Model> li = HF.Fenye(id, "Human_file", where1, "Huf_id", 3);
                return Content(JsonConvert.SerializeObject(li)); ;
            }
        }
        [HttpGet]
        public async Task<IActionResult> register(int id)
        {
            ViewBag.user = HttpContext.Session.GetString("Uname").ToString();
            Human_file_Model hfmm = await HF.SelByID02(id);
            Major_change_Model b = new Major_change_Model()
            {
                First_kind_id = hfmm.First_kind_id,
                First_kind_name = hfmm.First_kind_name,
                Second_kind_id = hfmm.Second_kind_id,
                Second_kind_name = hfmm.Second_kind_name,
                Third_kind_id = hfmm.Third_kind_id,
                Third_kind_name = hfmm.Third_kind_name,
                Major_id = hfmm.Human_major_id,
                Major_name = hfmm.Hunma_major_name,
                Major_kind_id = hfmm.Human_major_kind_id,
                Major_kind_name = hfmm.Human_major_kind_name,
                Human_id = hfmm.Human_id,
                Human_name = hfmm.Human_name,
                Salary_standard_id = hfmm.Salary_standard_id,
                Salary_standard_name = hfmm.Salary_standard_name,
                Salary_sum = Convert.ToDouble(hfmm.Salary_sum),
                Regist_time = DateTime.Now,
                Register = HttpContext.Session.GetString("Uname").ToString()
        };
            HttpContext.Session.SetString("f", b.First_kind_name.ToString());
            HttpContext.Session.SetString("s", b.Second_kind_name.ToString());
            HttpContext.Session.SetString("t", b.Third_kind_name.ToString());
            ViewData.Model = b;
            return View();
        }
        public IActionResult CMK() 
        {
            List<Config_major_kind_Model> list = cmk.config_majorSelect();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult CM( string id)
        {
            List<Config_major_Model> list = cm.config_majorSelect().Where(e => e.Major_kind_name == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult SS() 
        {
            List<Salary_standard_Model> list = ss.Select().Where(e => e.Check_status == 0).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult SS1(string id)
        {
            List<Salary_standard_Model> list = ss.Select().Where(e => e.Check_status == 0&e.Standard_name==id).ToList();
            return Json(list[0].Salary_sum);
        }
        [HttpPost]
        public async Task<IActionResult> register(Major_change_Model mcm) 
        {
            string firstname = HttpContext.Request.Form["emajorRelease.firstKindId"];
            string senconname = HttpContext.Request.Form["emajorRelease.secondKindId"];
            string thirdname = HttpContext.Request.Form["emajorRelease.thirdKindId"];
            string mkn = HttpContext.Request.Form["emajorRelease.Major_kindId"];
            string mn= HttpContext.Request.Form["emajorRelease.Major_Id"];
            string ss1 = HttpContext.Request.Form["emajorRelease.standardId"];
            string je = HttpContext.Request.Form["newsum"];
            List<Config_file_first_kind_Model> list = YJ.YJselect().Where(e => e.First_kind_name == firstname).ToList();
            mcm.New_first_kind_id = list[0].First_kind_id.ToString();
            mcm.New_first_kind_name = list[0].First_kind_name.ToString();
            List<Config_file_second_kind_Model> list1 = EJ.EJselect().Where(e => e.Second_kind_name == senconname).ToList();
            mcm.New_second_kind_id = list1[0].Second_kind_id.ToString();
            mcm.New_second_kind_name = list1[0].Second_kind_name.ToString();
            List<Config_file_third_kind_Model> list2 = SJ.SJselect().Where(e => e.Third_kind_name == thirdname).ToList();
            mcm.New_third_kind_id = list2[0].Third_kind_id.ToString();
            mcm.New_third_kind_name = list2[0].Third_kind_name.ToString();
            List<Config_major_Model> list3 = cm.config_majorSelect().Where(e => e.Major_kind_name == mkn).ToList();
            mcm.New_major_kind_id = list3[0].Major_kind_id;
            mcm.New_major_kind_name = list3[0].Major_kind_name.ToString();
            List<Config_major_Model> list4 = cm.config_majorSelect().Where(e => e.Major_name == mn).ToList();
            mcm.New_major_id = list4[0].Major_id;
            mcm.New_major_name = list4[0].Major_name.ToString();
            List<Salary_standard_Model> list5 = ss.Select().Where(e => e.Standard_name == ss1).ToList();
            mcm.New_salary_standard_id = list5[0].Standard_id;
            mcm.New_salary_standard_name = list5[0].Standard_name.ToString();
            mcm.New_salary_sum = Convert.ToDouble(je);
            mcm.Register = HttpContext.Session.GetString("Uname").ToString();
            mcm.Regist_time = DateTime.Now;
            if (await mc.Ad(mcm) > 0)
            {
                return RedirectToAction("index");
            }
            else 
            {
                return Content("<script>alert('失败')</script>");
            }
            
        }
    }
}