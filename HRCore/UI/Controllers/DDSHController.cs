using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace UI.Controllers
{
    public class DDSHController : Controller
    {
        private readonly Major_changeIBLL coreDbContext;
        private readonly Config_file_first_kindIBLL YJ;
        private readonly Config_file_second_kindIBLL EJ;
        private readonly config_file_third_kindIBLL SJ;
        private readonly Config_majorIBLL cm;
        private readonly Salary_standardModelIBLL ss;
        private readonly Major_changeIBLL mc;
        private readonly Human_fileIBLL hf;
        public DDSHController(Major_changeIBLL coreDbContext, Config_file_first_kindIBLL YJ, Config_file_second_kindIBLL EJ, config_file_third_kindIBLL SJ, Config_majorIBLL cm, Salary_standardModelIBLL ss,Major_changeIBLL mc, Human_fileIBLL hf)
        {
            this.hf = hf;
            this.mc = mc;
            this.cm = cm;
            this.ss = ss;
            this.YJ = YJ;
            this.EJ = EJ;
            this.SJ = SJ;
            this.coreDbContext = coreDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult check_list(int id) {
            string where = $@"Check_status=0";
            DBFenYe<Major_change_Model> li = coreDbContext.Fenye(id, "Major_change", where, "Mch_id", 3);
            return Content(JsonConvert.SerializeObject(li)); ;
        }
        public async Task<IActionResult> js_edit(int id) 
        {
            HttpContext.Session.SetString("id", id.ToString());
            ViewBag.user = HttpContext.Session.GetString("Uname").ToString();
            Major_change_Model b = await coreDbContext.SelByID02(id);
            HttpContext.Session.SetString("f", b.First_kind_name.ToString());
            HttpContext.Session.SetString("s", b.Second_kind_name.ToString());
            HttpContext.Session.SetString("t", b.Third_kind_name.ToString());
            ViewData.Model = b;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> js_edit(Major_change_Model mcm)
        {
            int id =Convert.ToInt32(HttpContext.Session.GetString("id").ToString());
            string firstname = HttpContext.Request.Form["emajorRelease.firstKindId"];
            string senconname = HttpContext.Request.Form["emajorRelease.secondKindId"];
            string thirdname = HttpContext.Request.Form["emajorRelease.thirdKindId"];
            string mkn = HttpContext.Request.Form["emajorRelease.Major_kindId"];
            string mn = HttpContext.Request.Form["emajorRelease.Major_Id"];
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
            mcm.Check_time = DateTime.Now;
            mcm.Mch_id = id;
            Human_file_Model hfm =  hf.SelByID0(mcm.Human_id);
            string zt = Request.Form["Check_status"];
            if (zt == "true")
                {
                    mcm.Check_status = 1;
                    hfm.First_kind_id = mcm.New_first_kind_id.Trim(' ');
                    hfm.First_kind_name = mcm.New_first_kind_name;
                    hfm.Second_kind_id = mcm.New_second_kind_id.Trim(' ');
                    hfm.Second_kind_name = mcm.New_second_kind_name;
                    hfm.Third_kind_id = mcm.New_third_kind_id.Trim(' ');
                    hfm.Third_kind_name = mcm.New_third_kind_name;
                    hfm.Human_major_id = mcm.New_major_id.Trim(' ');
                    hfm.Hunma_major_name = mcm.New_major_name;
                    hfm.Human_major_kind_id = mcm.New_major_kind_id.Trim(' ');
                    hfm.Human_major_kind_name = mcm.New_major_kind_name;
                    hfm.Salary_standard_id = mcm.New_salary_standard_id.Trim(' ');
                    hfm.Salary_standard_name = mcm.New_salary_standard_name;
                    hfm.Salary_sum = Convert.ToInt32(mcm.New_salary_sum);
                    hfm.Changer = mcm.Register;
                    hfm.Change_time = DateTime.Now;
                    hfm.Lastly_change_time = DateTime.Now;
                    hfm.Major_change_amount++;
                    hfm.File_chang_amount++;
                    mcm.Check_time = DateTime.Now;
                    mcm.Checker = mcm.Checker;
                    if (await mc.Up(mcm) > 0)
                    {
                        return RedirectToAction("index");
                    }
                    else
                    {
                        return RedirectToAction("index");
                    }
                }
                else
                {
                    mcm.Check_status = 2;
                    return RedirectToAction("index");
                }
        }

    
    }
}