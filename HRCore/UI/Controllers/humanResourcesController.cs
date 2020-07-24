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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace UI.Controllers
{
    public class humanResourcesController : Controller
    {
        private readonly IConfig_file_first_kindBLL First;
        private readonly IConfig_file_second_kindBLL Second;
        private readonly IConfig_file_third_kindBLL Third;
        private readonly IConfig_major_kindBLL Makind;
        private readonly IConfig_majorBLL Major;
        private readonly IUsersBLL user;
        private readonly IConfig_public_charBLL Char;
        private readonly IHuman_fileBLL Files;
        private readonly IWebHostEnvironment environment;
        private readonly IEngage_resumeBLL Resume;
        public humanResourcesController(IEngage_resumeBLL Resume,IHuman_fileBLL Files,IConfig_public_charBLL Char,IUsersBLL user,IConfig_majorBLL Major,IConfig_major_kindBLL Makind,IConfig_file_first_kindBLL First, IConfig_file_second_kindBLL Second, IConfig_file_third_kindBLL Third, IWebHostEnvironment environment)
        {
            this.Makind = Makind;
            this.Major = Major;
            this.First = First;
            this.Second = Second;
            this.Third = Third;
            this.user = user;
            this.Char = Char;
            this.Files = Files;
            this.environment = environment;
            this.Resume = Resume;
        }
        private void xiala4()
        {
            ViewBag.a2 = new List<SelectListItem>() {

                new SelectListItem(){Value="男",Text="男"},
                new SelectListItem(){Value="女",Text="女"}

            };
        }
        public ActionResult position_registerFirst()
        {
            List<Config_file_first_kind_Model> list = First.SelectFirst();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //二级
        public ActionResult position_registerSecond(string id)
        {
            string name = Request.Form["name"];
            id= Request.Form["id"];
            HttpContext.Session.SetString("First_kind_name", name);
            List<Config_file_second_kind_Model> list = Second.SelectSecond().Where(e => e.First_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //三级
        public ActionResult position_registerThird(string id)
        {
            string name = Request.Form["name2"];
            id = Request.Form["id"];
            HttpContext.Session.SetString("Second_kind_name", name);
            List<Config_file_third_kind_Model> list = Third.SelectThird().Where(e => e.Second_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public ActionResult xialaKong()
        {
            string name3 = Request.Form["name3"];
            HttpContext.Session.SetString("Third_kind_name", name3);
            string a = JsonConvert.SerializeObject(name3);
            return Json(a);
        }
        public ActionResult position_registerMakind()
        {
            List<Config_major_kind_Model> list = Makind.SelectMakind();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //职位名称
        public ActionResult position_registerMajor(string id)
        {
            string name = Request.Form["majokin"];
            id = Request.Form["id"];
            HttpContext.Session.SetString("Major_kind_name", name);
            List<Config_major_Model> list = Major.SelectsMajor().Where(e => e.Major_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult ssss()
        {
            string name = Request.Form["majorn"];
            HttpContext.Session.SetString("Major_name", name);
            string a = JsonConvert.SerializeObject(name);
            return Json(a);
        }
        public void Users()
        {
            List<Users_Model> list = user.Login();
            SelectList list2 = new SelectList(list, "U_id", "U_name");
            ViewData["o"] = list2;
        }
        public void xiala5()
        {
            List<Config_public_char_Model> list = Char.SelectChar().Where(e => e.Attribute_kind == "职称").ToList();
            SelectList list2 = new SelectList(list, "Attribute_name", "Attribute_name");
            ViewData["sa5"] = list2;
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
        public IActionResult human_register(int id)
        {
            position_registerFirst();
            position_registerMakind();
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
            int humanname =Convert.ToInt32(Request.Query["humanname"]);
            List<Engage_resume_Model> file_Model = Resume.ResumeUpSelect().Where(e=>e.Res_id==humanname).ToList();
             
            ViewTable table = new ViewTable() 
            {
                engage_Resumes=file_Model            
            };
            Users();
            return View(table);
        }
        [HttpPost]
        public async Task<IActionResult> human_register(Human_file_Model hrm)
        {
            string name = HttpContext.Session.GetString("First_kind_name");
            Random r = new Random();
            string suiji = r.Next(1, 99999999).ToString();
            Random r1 = new Random();
            string suiji1 = r1.Next(1, 999999).ToString();
            hrm.First_kind_name = name;
            hrm.First_kind_id = Request.Form["emajorRelease.firstKindId"];
            hrm.Second_kind_name = HttpContext.Session.GetString("Second_kind_name");
            hrm.Second_kind_id = Request.Form["emajorRelease.secondKindId"];
            hrm.Third_kind_name = HttpContext.Session.GetString("Third_kind_name");
            hrm.Third_kind_id = Request.Form["emajorRelease.thirdKindId"];
            hrm.Human_major_kind_name = HttpContext.Session.GetString("Major_kind_name");
            hrm.Human_major_kind_id = Request.Form["major_kind"];
            hrm.Hunma_major_name = HttpContext.Session.GetString("Major_name");
            hrm.Human_major_id = Request.Form["major_name"];
            hrm.Human_name = Request.Form["item.Human_name"]; 
            hrm.Human_sex = Request.Form["item.Human_sex"];
            hrm.Human_email = Request.Form["item.Human_email"];
            hrm.Human_telephone = Request.Form["item.Human_telephone"];
            hrm.Human_qq = Request.Form["Human_qq"];
            hrm.Human_mobilephone = Request.Form["item.Human_mobilephone"];
            hrm.Human_address = Request.Form["item.Human_address"];
            hrm.Human_postcode = Request.Form["item.Human_postcode"];
            hrm.Human_birthplace = Request.Form["item.Human_birthplace"];
            hrm.Human_birthday =Convert.ToDateTime(Request.Form["item.Human_birthday"]);
            hrm.Human_id_card = Request.Form["item.Human_idcard"]; 
            hrm.Human_society_security_id = Request.Form["Human_society_security_id"];
            hrm.Human_age =Convert.ToInt32(Request.Form["item.Human_age"]);
            hrm.Salary_standard_name = Request.Form["item.Salary_standard_name"];
            hrm.Human_bank = Request.Form["Human_bank"];
            hrm.Human_account = Request.Form["Human_account"]; 
            hrm.Register = Request.Form["item.Register"];
            hrm.Regist_time =Convert.ToDateTime(Request.Form["item.Regist_time"]);
            hrm.Human_histroy_records = Request.Form["item.Human_history_records"];
            hrm.Human_family_membership = Request.Form["Human_family_membership"];
            hrm.Remark = Request.Form["item.Remark"];
            hrm.Human_pro_designation = Request.Form["Human_pro_designation"];
            hrm.Human_nationality = Request.Form["item.Human_nationality"];
            hrm.Human_race = Request.Form["item.Human_race"];
            hrm.Human_religion = Request.Form["item.Human_religion"];
            hrm.Human_party = Request.Form["item.Human_party"];
            hrm.Human_educated_degree = Request.Form["item.Human_educated_degree"]; 
            hrm.Human_educated_years =Convert.ToInt32(Request.Form["item.Human_educated_years"]);
            hrm.Human_educated_major = Request.Form["item.Human_educated_major"];
            hrm.Human_speciality = Request.Form["item.Human_speciality"];
            hrm.Human_hobby = Request.Form["item.Human_hobby"];

            string humanid= "DA" + suiji;
            hrm.Human_id = humanid;
            hrm.Salary_standard_id = "HR" + suiji1;
            //hrm.First_kind_id = Request.Form["emajorRelease.firstKindId"];
            if (await Files.Add(hrm) > 0)
            {
                List<Human_file_Model> list = Files.SelectQuery().Where(e => e.Human_id == humanid).ToList();
                HttpContext.Session.SetString("Hufid", list[0].Huf_id.ToString());
                return RedirectToAction("register_choose_picture");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult register_choose_picture() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> register_choose_picture(IFormFileCollection file)
        {

            var path = "";
            foreach (var item in file)
            {
                //生成文件名
                string name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                //获取后缀名
                string ext = item.FileName.Substring(item.FileName.LastIndexOf('.'));
                //设置上传路径
                path = $"Uploader/" + name + ext;
                //生成文件的绝对路径
                var uploads = Path.Combine(environment.WebRootPath, path);
                //创建上传文件对应的文件夹
                (new FileInfo(uploads)).Directory.Create();
                using (var stream = new FileStream(uploads, FileMode.CreateNew))
                {
                    item.CopyTo(stream);//图片上传
                    //TempData["name"] = name + ext;//保存图片的值
                }
            }
          int ssid=Convert.ToInt32(HttpContext.Session.GetString("Hufid"));
            Human_file_Model sd = new Human_file_Model()
            {
                Human_picture ="../../"+ path,
                Huf_id = ssid
            };
            if (await Files.Updatepictr(sd)>0)
            {
                return RedirectToAction("check_list");
            }
            else
            {
                return RedirectToAction("register_choose_picture");
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
            fen.Where = "Check_status=0";
            fen.KeyName = "Huf_id";
            fen.TableName = "Human_file";
            List<Human_file_Model> page = Files.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
      
        [HttpGet]
        public async Task<IActionResult> human_check(int id)
        {
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
            position_registerFirst();
            position_registerMakind();
            Users();
            ViewData.Model = await Files.SelectById(id);
            Human_file_Model hr = new Human_file_Model();

            ViewBag.img = hr.Human_picture;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> human_check(Human_file_Model hfm)
        {
            hfm = new Human_file_Model()
            {
                Huf_id = Convert.ToInt32(Request.Form["Huf_id"]),
                Human_sex = Request.Form["Human_sex"],
                Human_pro_designation = Request.Form["Human_pro_designation"],
                Human_nationality = Request.Form["Human_nationality"],
                Human_race = Request.Form["Human_race"],
                Human_religion = Request.Form["Human_religion"],
                Human_party = Request.Form["Human_party"],
                Human_educated_degree = Request.Form["Human_educated_degree"],
                Human_educated_years = Convert.ToInt32(Request.Form["Human_educated_years"]),
                Human_educated_major = Request.Form["Human_educated_major"],
                Human_speciality = Request.Form["Human_speciality"],
                Human_hobby = Request.Form["Human_hobby"],
                Check_status=1,
                Check_time=Convert.ToDateTime(Request.Form["Check_time"]),
                Checker=Request.Form["Checker"],
                Salary_standard_name=Request.Form["Salary_standard_name"],

            };
            if (await Files.Update(hfm) > 0)
            {
                return RedirectToAction("query_locate");
            }
            else
            {
                return View(hfm);
            }
        }
        [HttpGet]
        public IActionResult query_locate()
        {
            position_registerFirst();
            position_registerMakind();
            return View();
        }
        [HttpPost]
        public IActionResult query_locate(Human_file_Model hm)
        {
            string major_kind_name = Request.Form["major_kind"];
            string major_name = Request.Form["major_name"];
            string first = Request.Form["emajorRelease.firstKindId"];
            string second = Request.Form["emajorRelease.secondKindId"];
            string third= Request.Form["emajorRelease.thirdKindId"];
            string start = Request.Form["utilBean.startDate"];
            string end = Request.Form["utilBean.endDate"];
            HttpContext.Session.SetString("First_kind_name", first);
            HttpContext.Session.SetString("Major_kind_name",major_kind_name);
            HttpContext.Session.SetString("Major_name",major_name);
            HttpContext.Session.SetString("Second_kind_name", second);
            HttpContext.Session.SetString("Third_kind_name", third);
            HttpContext.Session.SetString("startDate", start);
            HttpContext.Session.SetString("endDate", end);
            return RedirectToAction("query_list");

        }
        [HttpGet]
        public IActionResult change_list()
        {

            return View();
        }
        [HttpPost]

        public IActionResult change_list(FenYeModel fen)
        {
            string major_kind_name = HttpContext.Session.GetString("Major_kind_name");
            string major_name = HttpContext.Session.GetString("Major_name");
            string first = HttpContext.Session.GetString("First_kind_name");
            string second = HttpContext.Session.GetString("Second_kind_name");
            string third = HttpContext.Session.GetString("Third_kind_name");
            string start = HttpContext.Session.GetString("startDate");
            string end = HttpContext.Session.GetString("endDate");
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
        
            fen.Where = $@"Check_status=1 and First_kind_id like'%" + first + "%'and Human_major_id like '%" + major_name + "%'and Human_major_kind_id like '%" + major_kind_name + "%'and Second_kind_id like '%" + second + "%'and Third_kind_id like '%" + third + "%'and Regist_time>'" + start + "'and Regist_time<'" + end + "'";
            fen.KeyName = "Huf_id";
            fen.TableName = "Human_file";
            List<Human_file_Model> page = Files.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpGet]
        public IActionResult change_keywords()
        {
            return View();
        }
        [HttpPost]
        public IActionResult change_keywords(Human_file_Model hm)
        {
            string name = Request.Form["Human_name"];
            HttpContext.Session.SetString("Human_name", name);
            return RedirectToAction("change_keywordslist");
        }
        [HttpGet]
        public IActionResult change_keywordslist()
        {
            return View();
        }
        [HttpPost]

        public IActionResult change_keywordslist(FenYeModel fen)
        {
            string name = HttpContext.Session.GetString("Human_name");
           
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = Convert.ToInt32(currentPage);
            fen.PageSize = 3;

            fen.Where = $@"Human_name like '%{name}%' ";
            fen.KeyName = "Huf_id";
            fen.TableName = "Human_file";
            List<Human_file_Model> page = Files.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        public async Task<IActionResult> query_list_information(int id)
        {
           
            Human_file_Model list =await Files.SelectById(id);
            ViewData.Model = list;
            return View();
        }
        [HttpGet]
        public IActionResult change_locate()
        {
            position_registerFirst();
            position_registerMakind();
            return View();
        }
        [HttpPost]
        public IActionResult change_locate(int id)
        {
            string major_kind_name = Request.Form["major_kind"];
            string major_name = Request.Form["major_name"];
            string first = Request.Form["emajorRelease.firstKindId"];
            string second = Request.Form["emajorRelease.secondKindId"];
            string third = Request.Form["emajorRelease.thirdKindId"];
            string start = Request.Form["utilBean.startDate"];
            string end = Request.Form["utilBean.endDate"];
            HttpContext.Session.SetString("First_kind_name", first);
            HttpContext.Session.SetString("Major_kind_name", major_kind_name);
            HttpContext.Session.SetString("Major_name", major_name);
            HttpContext.Session.SetString("Second_kind_name", second);
            HttpContext.Session.SetString("Third_kind_name", third);
            HttpContext.Session.SetString("startDate", start);
            HttpContext.Session.SetString("endDate", end);
            return RedirectToAction("change_list");
        }
        [HttpGet]
        public IActionResult query_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult query_list(FenYeModel fen)
        {
            string major_kind_name = HttpContext.Session.GetString("Major_kind_name");
            string major_name = HttpContext.Session.GetString("Major_name");
            string first = HttpContext.Session.GetString("First_kind_name");
            string second = HttpContext.Session.GetString("Second_kind_name");
            string third = HttpContext.Session.GetString("Third_kind_name");
            string start = HttpContext.Session.GetString("startDate");
            string end = HttpContext.Session.GetString("endDate");
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;

            fen.Where = $@"Check_status=1 and First_kind_id like'%" + first + "%'and Human_major_id like '%" + major_name + "%'and Human_major_kind_id like '%" + major_kind_name + "%'and Second_kind_id like '%" + second + "%'and Third_kind_id like '%" + third + "%'and Regist_time>'" + start + "'and Regist_time<'" + end + "'";
            fen.KeyName = "Huf_id";
            fen.TableName = "Human_file";
            List<Human_file_Model> page = Files.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpGet]
        public IActionResult query_keywords()
        {
            return View();
        }
        [HttpPost]
        public IActionResult query_keywords(Human_file_Model hm)
        {
            string name = Request.Form["Human_name"];
            HttpContext.Session.SetString("Human_name", name);
            return RedirectToAction("query_keywordslist");
        }
        [HttpGet]
        public IActionResult query_keywordslist()
        {
            return View();
        }
        [HttpPost]

        public IActionResult query_keywordslist(FenYeModel fen)
        {
            string name = HttpContext.Session.GetString("Human_name");

            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = Convert.ToInt32(currentPage);
            fen.PageSize = 3;

            fen.Where = $@"Human_name like '%{name}%' ";
            fen.KeyName = "Huf_id";
            fen.TableName = "Human_file";
            List<Human_file_Model> page = Files.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        public async Task<IActionResult> change_list_information(int id) 
        {
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
            Human_file_Model list = await Files.SelectById(id);
            ViewData.Model = list;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> change_list_information(Human_file_Model hfm)
        {
            hfm = new Human_file_Model()
            {
                Huf_id = Convert.ToInt32(Request.Form["Huf_id"]),
                Human_sex = Request.Form["Human_sex"],
                Human_pro_designation = Request.Form["Human_pro_designation"],
                Human_nationality = Request.Form["Human_nationality"],
                Human_race = Request.Form["Human_race"],
                Human_religion = Request.Form["Human_religion"],
                Human_party = Request.Form["Human_party"],
                Human_educated_degree = Request.Form["Human_educated_degree"],
                Human_educated_years = Convert.ToInt32(Request.Form["Human_educated_years"]),
                Human_educated_major = Request.Form["Human_educated_major"],
                Human_speciality = Request.Form["Human_speciality"],
                Human_hobby = Request.Form["Human_hobby"],
                Changer = HttpContext.Session.GetString("UName"),
                Change_time=DateTime.Now,
                Salary_standard_name = Request.Form["Salary_standard_name"],
            };
            if (await Files.FileUpdate(hfm) > 0)
            {
                return RedirectToAction("change_locate");
            }
            else
            {
                return View(hfm);
            }
        }
       
    }
}