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
    public class deleteController : Controller
    {
        private readonly IConfig_file_first_kindBLL1 First;
        private readonly IConfig_file_second_kindBLL1 Second;
        private readonly IConfig_file_third_kindBLL1 Third;
        private readonly IConfig_major_kindBLL1 Makind;
        private readonly IConfig_majorBLL1 Major;
        private readonly IUsersBLL1 user;
        private readonly IConfig_public_charBLL1 Char;
        private readonly IHuman_fileBLL1 Files;
        public deleteController(IHuman_fileBLL1 Files, IConfig_public_charBLL1 Char, IUsersBLL1 user, IConfig_majorBLL1 Major, IConfig_major_kindBLL1 Makind, IConfig_file_first_kindBLL1 First, IConfig_file_second_kindBLL1 Second, IConfig_file_third_kindBLL1 Third)
        {
            this.Makind = Makind;
            this.Major = Major;
            this.First = First;
            this.Second = Second;
            this.Third = Third;
            this.user = user;
            this.Char = Char;
            this.Files = Files;
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
            id = Request.Form["id"];
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
        [HttpGet]
        public IActionResult delete_locate()
        {
            position_registerFirst();
            position_registerMakind();
            return View();
        }
        [HttpPost]
        public IActionResult delete_locate(Human_file_Model hm)
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
            return RedirectToAction("delete_list");
        }
        [HttpGet]
        public IActionResult delete_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult delete_list(FenYeModel fen)
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

            fen.Where = $@"Human_file_status='False' and First_kind_id like'%" + first + "%'and Human_major_id like '%" + major_name + "%'and Human_major_kind_id like '%" + major_kind_name + "%'and Second_kind_id like '%" + second + "%'and Third_kind_id like '%" + third + "%'and Regist_time>'" + start + "'and Regist_time<'" + end + "'";
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
        public async Task<IActionResult> delete_list_information(int id)
        {
            Human_file_Model list = await Files.SelectById(id);
            ViewData.Model = list;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> delete_list_information(Human_file_Model hm)
        {
            hm = new Human_file_Model()
            {
                Human_file_status = true,
                Huf_id = Convert.ToInt32(Request.Form["Huf_id"]),
            };
            if (await Files.Updatestatus(hm) > 0)
            {
                return RedirectToAction("recovery_locate");
            }
            else
            {
                return View(hm);
            }

        }
        [HttpGet]
        public IActionResult delete_keywords()
        {
            return View();
        }
        [HttpPost]
        public IActionResult delete_keywords(Human_file_Model hm)
        {
            string name = Request.Form["Human_name"];
            HttpContext.Session.SetString("Human_name", name);
            return RedirectToAction("delete_keywordslist");
        }
        [HttpGet]
        public IActionResult delete_keywordslist()
        {
            return View();
        }
        [HttpPost]

        public IActionResult delete_keywordslist(FenYeModel fen)
        {
            string name = HttpContext.Session.GetString("Human_name");

            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = Convert.ToInt32(currentPage);
            fen.PageSize = 3;

            fen.Where = $@"Human_file_status='False' and Human_name like '%{name}%' ";
            fen.KeyName = " Huf_id";
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
        public IActionResult recovery_locate()
        {
            position_registerFirst();
            position_registerMakind();
            return View();
        }
        [HttpPost]
        public IActionResult recovery_locate(Human_file_Model hm)
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
            return RedirectToAction("recovery_list");
        }
        [HttpGet]
        public IActionResult recovery_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult recovery_list(FenYeModel fen)
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

            fen.Where = $@"Human_file_status='True' and First_kind_id like'%" + first + "%'and Human_major_id like '%" + major_name + "%'and Human_major_kind_id like '%" + major_kind_name + "%'and Second_kind_id like '%" + second + "%'and Third_kind_id like '%" + third + "%'and Regist_time>'" + start + "'and Regist_time<'" + end + "'";
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
        public async Task<IActionResult> recovery_list_information(int id)
        {
            Human_file_Model list = await Files.SelectById(id);
            ViewData.Model = list;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> recovery_list_information(Human_file_Model hm)
        {
            hm = new Human_file_Model()
            {
                Human_file_status = false,
                Huf_id = Convert.ToInt32(Request.Form["Huf_id"]),
            };
            if (await Files.Updatestatus(hm) > 0)
            {
                return RedirectToAction("delete_locate");
            }
            else
            {
                return View(hm);
            }
        }
        [HttpGet]
        public IActionResult recovery_keywords()
        {
            return View();
        }
        [HttpPost]
        public IActionResult recovery_keywords(Human_file_Model hm)
        {
            string name = Request.Form["Human_name"];
            HttpContext.Session.SetString("Human_name", name);
            return RedirectToAction("recovery_keywordslist");
         
        }
        [HttpGet]
        public IActionResult recovery_keywordslist()
        {
            return View();
        }
        [HttpPost]   
        public IActionResult recovery_keywordslist(FenYeModel fen)
        {
            string name = HttpContext.Session.GetString("Human_name");

            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = Convert.ToInt32(currentPage);
            fen.PageSize = 3;

            fen.Where = $@"Human_file_status='True' and Human_name like '%{name}%' ";
            fen.KeyName = " Huf_id";
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
        public IActionResult delete_forever_list()
        {
            return View();
        }
        [HttpPost]

        public IActionResult delete_forever_list(FenYeModel fen)
        {  
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = Convert.ToInt32(currentPage);
            fen.PageSize = 3;

            fen.Where = "";
            fen.KeyName = " Huf_id";
            fen.TableName = "Human_file";
            List<Human_file_Model> page = Files.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpPost]
        public async Task <IActionResult> delete_forever_list1(short id)
        {
            int result = await Files.deleteid(id);
            return Content(JsonConvert.SerializeObject(result));
        }
    }
}