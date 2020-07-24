using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using IBLL;
using EFEntity;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class positionController : Controller
    {
        private readonly IUsersBLL users;
        private readonly IConfig_file_first_kindBLL First;
        private readonly IConfig_file_second_kindBLL Second;
        private readonly IConfig_file_third_kindBLL Third;
        private readonly IConfig_major_kindBLL Makind;
        private readonly IConfig_majorBLL Major;
        private readonly IEngage_major_releaseBLL replease;
        public positionController(IEngage_major_releaseBLL replease,IConfig_major_kindBLL Makind, IConfig_majorBLL Major, IUsersBLL users, IConfig_file_first_kindBLL First, IConfig_file_second_kindBLL Second, IConfig_file_third_kindBLL Third)
        {
            this.Makind = Makind;
            this.Major = Major;
            this.users = users;
            this.First = First;
            this.Second = Second;
            this.Third = Third;
            this.replease = replease;
        }
        //职业发布登记
        [HttpGet]
        public IActionResult position_register()
        {
            GetList6();
            GetList7();
            ViewBag.Name = HttpContext.Session.GetString("UName");
            return View();
        }

        [HttpPost]
        private void GetList6()
        {
            ViewBag.hard_value = new List<SelectListItem>() {

                new SelectListItem(){Value="校园招聘",Text="校园招聘"},
                new SelectListItem(){Value="社会招聘",Text="社会招聘"}

            };
        }
        public void GetList7()
        {

            List<Users_Model> list = users.Login();
            SelectList list2 = new SelectList(list, "U_id", "U_name");
            ViewData["o"] = list2;
        }
        //一级
        public ActionResult position_registerFirst()
        {
            List<Config_file_first_kind_Model> list = First.SelectFirst();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //二级
        public ActionResult position_registerSecond(string id)
        {
            List<Config_file_second_kind_Model> list = Second.SelectSecond().Where(e => e.First_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //三级
        public ActionResult position_registerThird(string id)
        {
            List<Config_file_third_kind_Model> list = Third.SelectThird().Where(e => e.Second_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //职位分类
        public ActionResult position_registerMakind()
        {
            List<Config_major_kind_Model> list = Makind.SelectMakind();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //职位名称
        public ActionResult position_registerMajor(string id)
        {
            List<Config_major_Model> list = Major.SelectsMajor().Where(e => e.Major_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //添加
        public async Task<ActionResult> position_register(Engage_major_release_Model cffm)
        {
            string first = Request.Form["emajorRelease.FirstKindId"];
            string second = Request.Form["emajorRelease.SecondKindId"];
            string third = Request.Form["emajorRelease.ThirdKindId"];
            string major_kind = Request.Form["Major_kind"];
            string major = Request.Form["Major_name"];
            cffm.First_kind_id = first;
            cffm.Second_kind_id = second; ;
            cffm.Third_kind_id = third;
            cffm.Major_kind_id = major_kind;
            cffm.Major_id = major;
            string name = Request.Form["Register"];           
            List<Users_Model> um= users.SeledctUser(int.Parse(name));
            cffm.Register = um[0].U_name;
            Config_file_first_kind_Model c = new Config_file_first_kind_Model()
            {
                First_kind_id = cffm.First_kind_id
            };
            List<Config_file_first_kind_Model> list2 = First.SelectFirst().Where(e => e.First_kind_id == c.First_kind_id).ToList();
            cffm.First_kind_name = list2[0].First_kind_name;
            Config_file_second_kind_Model c1 = new Config_file_second_kind_Model()
            {
                Second_kind_id = cffm.Second_kind_id
            };
            List<Config_file_second_kind_Model> list3 = Second.SelectSecond().Where(e => e.Second_kind_id == c1.Second_kind_id).ToList();
            cffm.Second_kind_name = list3[0].Second_kind_name;
            Config_file_third_kind_Model c2 = new Config_file_third_kind_Model()
            {
                Third_kind_id = cffm.Third_kind_id
            };
            List<Config_file_third_kind_Model> list4 = Third.SelectThird().Where(e => e.Third_kind_id == c2.Third_kind_id).ToList();
            cffm.Third_kind_name = list4[0].Third_kind_name;
            Config_major_kind_Model c4 = new Config_major_kind_Model()
            {
                Major_kind_id = cffm.Major_kind_id
            };
            List<Config_major_kind_Model> list5 = Makind.SelectMakind().Where(e => e.Major_kind_id == c4.Major_kind_id).ToList();
            cffm.Major_kind_name = list5[0].Major_kind_name;
            Config_major_Model c6 = new Config_major_Model()
            {
                Major_id = cffm.Major_id
            };
            List<Config_major_Model> list6 = Major.SelectsMajor().Where(e => e.Major_id == c6.Major_id).ToList();
            cffm.Major_name = list6[0].Major_name;

            if (await replease.Add(cffm) > 0)
            {

                //return Content("<script>alert('添加成功');window.location.href='/position/position_change_update'</script>");
                return RedirectToAction("position_change_update");
            }
            else
            {
                GetList6();
                GetList7();
                return RedirectToAction("position_register");
            }

        }   

        [HttpGet]
        public IActionResult position_change_update()
        {
            return View();
        }
        [HttpPost]

        public IActionResult position_change_update(FenYeModel fen)
        {
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());            
            fen.PageSize = 3;
            fen.Where = "";
            fen.KeyName = "Mre_id";
            fen.TableName = "Engage_major_release";
            List<Engage_major_release_Model> page = replease.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        public async Task<IActionResult> Del(short id)
        {
            int result =await replease.Del(id);
            return Content(JsonConvert.SerializeObject(result));
        }
        [HttpGet]
        public async Task<IActionResult> position_release_change(int id)
        {
            GetList7();
            GetList6();
            ViewData.Model = await replease.SelectById(id);
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> position_release_change(Engage_major_release_Model cffkm)
        {
            cffkm.Changer = Request.Form["Changer"];
            cffkm.Change_time =Convert.ToDateTime(Request.Form["Change_time"]);
            cffkm.Major_describe = Request.Form["Major_describe"];
            cffkm.Engage_required = Request.Form["Engage_required"];
            if (await replease.Update(cffkm) > 0)
            {
                return RedirectToAction("position_release_search");
            }
            else
            {
                return View(cffkm);
            }
        }
        [HttpGet]
        public IActionResult position_release_search()
        {
            return View();
        }
    }
}