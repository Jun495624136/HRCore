using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using IBLL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Controllers
{
    public class XQGLController : Controller
    {
        private readonly UsersIBLL coreDbContext;
        private readonly JueSeIBLL JSbl;
        public XQGLController(UsersIBLL coreDbContext, JueSeIBLL JSbl)
        {
            this.coreDbContext = coreDbContext;
            this.JSbl = JSbl;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult check_list(int id)
        {
            DBFenYe<Users_Model> li = coreDbContext.Fenye(id, "Users", " ", "U_id", 3);
            return Content(JsonConvert.SerializeObject(li)); 
        }
        [HttpGet]
        public async Task<IActionResult> user_add()
        {
            await NewMethod();
            return View();
        }
        private async Task NewMethod()
        {
            List<JueSeModel> list =await JSbl.RoleSelect();
            SelectList si1 = new SelectList(list, "JueSe_id", "JueSe_name");
            ViewData["s"] = si1;
        }
        [HttpPost]
        public async Task<ActionResult> user_add(Users_Model um)
        {
            int a = Convert.ToInt32(um.JueSe_name);
            List<JueSeModel> list1 = await JSbl.RoleSelect()/*.Where(e => e.JueSe_id == Convert.ToInt32(um.JueSe_name)).ToList()*/;
            foreach (JueSeModel item in list1)
            {
                if (item.JueSe_id == a ) 
                {
                    um.JueSe_name = item.JueSe_name;
                };
            }
            
            if (ModelState.IsValid)
            {
                if (await coreDbContext.UserCreate(um) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    await NewMethod();
                    return View(um);
                }
            }
            else
            {
                await NewMethod();
                return View(um);
            }
        }
        public async Task<int> Del(int id)
        {
            if (await coreDbContext.UserDelete(id) > 0)
            {
                return 1;
            }
            else {
                return 0;
            }
        }
        [HttpGet]
        public async Task<ActionResult> user_edit(int id)
        {
            Users_Model list1 = coreDbContext.UserSelectBy(id);
            List<JueSeModel> list2 = await JSbl.RoleSelect();/*.Where(e => )*/
            foreach (JueSeModel item in list2)
            {
                if (item.JueSe_name == list1.JueSe_name) 
                {
                    list1.JueSe_name = Convert.ToString(item.JueSe_id);
                }
            }
            await NewMethod();
            ViewData.Model = list1;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> user_edit(Users_Model um)
        {
            int a = Convert.ToInt32(um.JueSe_name);
            List<JueSeModel> list1 = await JSbl.RoleSelect();
            foreach (JueSeModel item in list1)
            {
                if (item.JueSe_id == a)
                {
                     um.JueSe_name = item.JueSe_name;
                }
            }

            if (ModelState.IsValid)
            {
                if (await coreDbContext.UserEdit(um) > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Model = um;
                    return View(um.U_id);
                }
            }
            else
            {
                ViewData.Model = um;
                return View(um.U_id);
            }

        }
    }
}