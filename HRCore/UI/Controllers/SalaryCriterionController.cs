using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using Model;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace UI.Controllers
{
    public class SalaryCriterionController : Controller
    {
        private readonly ISalary_standard_BLL ssbll;
        private readonly ISalary_standard_details_BLL ssdbll;
        public SalaryCriterionController(ISalary_standard_BLL ssbll, ISalary_standard_details_BLL ssdbll) 
        {
            this.ssbll = ssbll;
            this.ssdbll = ssdbll;
        }
        #region 薪酬标准登记 
        [HttpGet]
        public IActionResult Salarystandard_register()
        {
            Random rd = new Random();
            string suijihao = rd.Next(1, 999999).ToString();
            ViewBag.BH = "HR" + suijihao;
            ViewBag.Name = HttpContext.Session.GetString("UName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Salarystandard_register(Salary_standard_Model salary_) 
        {
            int result = 0;
            salary_.Register = HttpContext.Session.GetString("UName");
            Salary_standard_details_Model sdm = new Salary_standard_details_Model()
            {
                Standard_id = salary_.Standard_id,
                Standard_name = salary_.Standard_name
            };
            string[] item_id = Request.Form["details.itemId"];
            string[] item_Name = Request.Form["details.itemName"];
            string[] salary = Request.Form["details.salary"];
            for (int i = 0; i < item_id.Length; i++)
            {
                sdm.Item_id = Convert.ToInt32(item_id[i]);
                sdm.Item_name = item_Name[i];
                sdm.Salary = Convert.ToDouble(salary[i]);
                result = await ssdbll.ISalary_standard_details_Add(sdm);
            }
            result = await ssbll.Salary_standard_Add(salary_);
            if (result > 0)
            {
                return RedirectToAction("Salarystandard_register_success");
            }
            else
            {
                return RedirectToAction("Salarystandard_register");
            }
        }

        public IActionResult Salarystandard_register_success() 
        {
            return View();
        }

        #endregion

        #region 薪酬标准登记复核查询分页
        [HttpGet]
        public IActionResult Salarystandard_check_list() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salarystandard_check_list(FenYeModel fen)
        {
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = " Check_status=0";
            fen.KeyName = "Ssd_id";
            fen.TableName = "Salary_standard";
            List<Salary_standard_Model> page = ssbll.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        #endregion

        #region 薪酬标准登记复核成功
        [HttpGet]
        public IActionResult Salarystandard_check()
        {
            string Standard_id = Request.Query["Standard_id"];
            ViewBag.cheNmae = HttpContext.Session.GetString("UName");
            List<Salary_standard_Model> stm = ssbll.Salary_standard_Select().Where(e => e.Standard_id == Standard_id).ToList();
            List<Salary_standard_details_Model> sdm = ssdbll.Salary_standard_details_Select().Where(e => e.Standard_id == Standard_id).ToList();
            ViewTable table = new ViewTable()
            {
                Salary_standard = stm,
                Salary_standard_details = sdm
            };
            return View(table);
        }
        [HttpPost]
        public async Task<IActionResult> Salarystandard_check(Salary_standard_Model salary_) 
        {
            int result;
            string[] salary = Request.Form["item2.Salary"];
            string[] sdtid = Request.Form["item2.Sdt_id"];
            string standardName = Request.Form["item.Standard_name"];
            for (int i = 0; i < salary.Length; i++)
            {
                Salary_standard_details_Model _Model = new Salary_standard_details_Model()
                {
                    Salary = Convert.ToDouble(salary[i]),
                    Sdt_id = Convert.ToInt32(sdtid[i]),
                    Standard_name = standardName
                };
                result =await ssdbll.Salary_standard_details_Update(_Model);
            }
            salary_ = new Salary_standard_Model()
            {
                Ssd_id = Convert.ToInt32(Request.Form["item.Ssd_id"]),
                Standard_name = Request.Form["item.Standard_name"],
                Designer = Request.Form["item.Designer"],
                Check_status = 1,
                Checker = Request.Form["item.Checker"],
                Check_time = Convert.ToDateTime(Request.Form["item.Check_time"]),
                Salary_sum = Convert.ToDouble(Request.Form["item.Salary_sum"]),
                Check_comment = Request.Form["item.Check_comment"],
            };
            result =await ssbll.Salary_standard_CheckerUpdate(salary_);
            if (result > 0)
            {
                return RedirectToAction("Salarystandard_check_success");
            }
            else
            {
                return RedirectToAction("Salarystandard_check_list");
            }
        }
        public IActionResult Salarystandard_check_success() 
        {
            return View();
        }
        #endregion

        #region 薪酬标准查询
        [HttpGet]
        public IActionResult Salarystandard_query_locate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salarystandard_query_locate(string standardId1)
        {

            standardId1 = Request.Form["Standard_id"];
            string primarKey1 = Request.Form["Designer"];
            string date_start1 = Request.Form["date_start"];
            string date_end1 = Request.Form["date_end"];
            HttpContext.Session.SetString("standardId", standardId1);
            HttpContext.Session.SetString("primarKey", primarKey1);
            HttpContext.Session.SetString("date_start", date_start1);
            HttpContext.Session.SetString("date_end", date_end1);
            if (standardId1 != "" || primarKey1 != "" || date_start1 != "" || date_end1 != "")
            {
                return RedirectToAction("Salarystandard_query_list");
            }
            else
            {
                //return Content("<script>alert('不能为空,请输入!');window.location.href='/SalaryCriterion/Salarystandard_query_locate';</script>", "text/html");
                return RedirectToAction("Salarystandard_query_locate");
            }
        }

        [HttpGet]
        public IActionResult Salarystandard_query_list() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salarystandard_query_list(FenYeModel fenYe)
        {
            string standardId =HttpContext.Session.GetString("standardId");
            string primarKey = HttpContext.Session.GetString("primarKey");
            DateTime date_start = Convert.ToDateTime(HttpContext.Session.GetString("date_start"));
            DateTime date_end = Convert.ToDateTime(HttpContext.Session.GetString("date_end"));
            int N = date_end.Year;
            int Y = date_end.Month;
            int R = date_end.Day + 1;
            DateTime dateTime = Convert.ToDateTime(N + "-" + Y + "-" + R);

            string currentPage = Request.Form["currentPage"];
            fenYe.CurrentPage = int.Parse(currentPage.ToString());
            fenYe.PageSize = 3;
            fenYe.Where = " Check_status=1 and Standard_id like '%" + standardId + "%' and Designer like '%" + primarKey + "%' and Regist_time > '" + date_start + "' and Regist_time < '" + dateTime + "' ";
            fenYe.KeyName = "Ssd_id";
            fenYe.TableName = "Salary_standard";
            List<Salary_standard_Model> page = ssbll.FenYe(fenYe);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fenYe.Pages;
            di["rows"] = fenYe.Rows;
            di["PageSize"] = fenYe.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        #endregion

        #region 薪酬标准登记查询打印
        [HttpGet]
        public IActionResult Salarystandard_query()
        {
            string Standard_id = Request.Query["Standard_id"];
            ViewBag.cheNmae = HttpContext.Session.GetString("UName");
            List<Salary_standard_Model> stm = ssbll.Salary_standard_Select().Where(e => e.Standard_id == Standard_id).ToList();
            List<Salary_standard_details_Model> sdm = ssdbll.Salary_standard_details_Select().Where(e => e.Standard_id == Standard_id).ToList();
            ViewTable table = new ViewTable()
            {
                Salary_standard = stm,
                Salary_standard_details = sdm
            };
            return View(table);
        }
        [HttpPost]
        public IActionResult Salarystandard_query(string Checker)
        {
            string BH = "薪酬编号:" + Request.Form["item.Standard_id"];
            string MC = "薪酬标准名称:" + Request.Form["item.Standard_name"];
            string ZE = "薪酬总额:" + Request.Form["item.Salary_sum"];
            string ZDR = "制定人:" + Request.Form["item.Designer"];
            string FHR = "复核人:" + Request.Form["item.Checker"];
            string FHTime = "复核时间:" + Request.Form["item.Check_time"];
            string BZ = "备注:" + Request.Form["item.Remark"];
            string[] Item_id = Request.Form["item2.Item_id"];
            string[] Item_name = Request.Form["item2.Item_name"];
            string[] salary = Request.Form["item2.Salary"];
            FileStream fs = new FileStream("D:\\薪酬标准.txt", FileMode.OpenOrCreate, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("打印人:" + HttpContext.Session.GetString("UName"));
                sw.Write(BH + "\t\t" + MC + "\t\t" + ZE + "\n");
                sw.Write(ZDR + "\t\t" + FHR + "\t\t" + FHTime + "\n");
                sw.Write(BZ + "\n");
                sw.WriteLine("序号\t\t薪酬项目名称\t\t金额");
                for (int i = 0; i < Item_id.Length; i++)
                {
                    sw.WriteLine(Item_id[i] + "\t\t" + Item_name[i] + "\t\t\t" + salary[i]);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            };
            return RedirectToAction("Salarystandard_query_success");
        }

        public IActionResult Salarystandard_query_success() 
        {
            return View();
        }
        #endregion

        #region 薪酬标准变更
        [HttpGet]
        public IActionResult Salarystandard_change_locate() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salarystandard_change_locate(string standardId1)
        {
            standardId1 = Request.Form["Standard_id"];
            string primarKey1 = Request.Form["Designer"];
            string date_start1 = Request.Form["date_start"];
            string date_end1 = Request.Form["date_end"];
            HttpContext.Session.SetString("standardId2", standardId1);
            HttpContext.Session.SetString("primarKey2", primarKey1);
            HttpContext.Session.SetString("date_start2", date_start1);
            HttpContext.Session.SetString("date_end2", date_end1);
            if (standardId1 != "" || primarKey1 != "" || date_start1 != "" || date_end1 != "")
            {
                return RedirectToAction("Salarystandard_change_list");
            }
            else
            {
                return RedirectToAction("Salarystandard_change_locate");
            }
        }
        [HttpGet]
        public IActionResult Salarystandard_change_list() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salarystandard_change_list(FenYeModel fenYe)
        {
            string standardId2 =HttpContext.Session.GetString("standardId2");
            string primarKey2 = HttpContext.Session.GetString("primarKey2");
            DateTime date_start2 = Convert.ToDateTime(HttpContext.Session.GetString("date_start2"));
            DateTime date_end2 = Convert.ToDateTime(HttpContext.Session.GetString("date_end2"));
            int N = date_end2.Year;
            int Y = date_end2.Month;
            int R = date_end2.Day + 1;
            DateTime dateTime2 = Convert.ToDateTime(N + "-" + Y + "-" + R);

            string currentPage = Request.Form["currentPage"];
            fenYe.CurrentPage = int.Parse(currentPage.ToString());
            fenYe.PageSize = 3;
            fenYe.Where = " Change_status=0 and Standard_id like '%" + standardId2 + "%' and Designer like '%" + primarKey2 + "%' and Regist_time > '" + date_start2 + "' and Regist_time < '" + dateTime2 + "' ";
            fenYe.KeyName = "Ssd_id";
            fenYe.TableName = "Salary_standard";
            List<Salary_standard_Model> page = ssbll.FenYe(fenYe);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fenYe.Pages;
            di["rows"] = fenYe.Rows;
            di["PageSize"] = fenYe.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpGet]
        public IActionResult Salarystandard_change(string Standard_id) 
        {
            Standard_id = Request.Query["Standard_id"];
            ViewBag.cheNmae =HttpContext.Session.GetString("UName");
            List<Salary_standard_Model> stm = ssbll.Salary_standard_Select().Where(e => e.Standard_id == Standard_id).ToList();
            List<Salary_standard_details_Model> sdm = ssdbll.Salary_standard_details_Select().Where(e => e.Standard_id == Standard_id).ToList();
            ViewTable table = new ViewTable()
            {
                Salary_standard = stm,
                Salary_standard_details = sdm
            };
            return View(table);
        }

        [HttpPost]
        public async Task<IActionResult> Salarystandard_change()
        {
            if (ModelState.IsValid)
            {
                int result;
                string[] salary = Request.Form["item2.Salary"];
                string[] sdtid = Request.Form["item2.Sdt_id"];
                string standardName = Request.Form["item.Standard_name"];
                for (int i = 0; i < salary.Length; i++)
                {
                    Salary_standard_details_Model _Model = new Salary_standard_details_Model()
                    {
                        Salary = Convert.ToDouble(salary[i]),
                        Sdt_id = Convert.ToInt32(sdtid[i]),
                        Standard_name = standardName
                    };
                    result =await ssdbll.Salary_standard_details_Update(_Model);
                }
                Salary_standard_Model salary1 = new Salary_standard_Model()
                {
                    Ssd_id = Convert.ToInt32(Request.Form["item.Ssd_id"]),
                    Standard_name = standardName,
                    Designer = Request.Form["item.Designer"],
                    Check_status = 0,
                    Salary_sum = Convert.ToDouble(Request.Form["item.Salary_sum"]),
                    Remark = Request.Form["item.Remark"],
                    Changer = Request.Form["item.Changer"],
                    Change_status = 1,
                    Change_time = Convert.ToDateTime(Request.Form["item.Change_time"])
                };
                result = await ssbll.Salary_standard_Update(salary1);
                if (result > 0)
                {
                    return RedirectToAction("Salarystandard_change_success");
                }
                else
                {
                    return RedirectToAction("Salarystandard_change_list");
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult Salarystandard_change_success()
        {
            return View();
        }
        #endregion
    }
}