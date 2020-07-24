 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IBLL;
using Model;
using Newtonsoft.Json;
namespace UI.Controllers
{
    public class SalaryGrantController : Controller
    {
        private readonly ISalary_grantBLL sgbll;
        private readonly ISalary_standard_details_BLL ssdbll;
        private readonly ISalary_grant_detailsBLL sgdbll;
        public SalaryGrantController(ISalary_grantBLL sgbll, ISalary_standard_details_BLL ssdbll, ISalary_grant_detailsBLL sgdbll)
        {
            this.sgbll = sgbll;
            this.ssdbll = ssdbll;
            this.sgdbll = sgdbll;
        }
        #region 薪酬发放登记
        [HttpGet]
        public IActionResult Register_locate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register_locate(string selectId)
        {
            selectId = Request.Form["submitType"];
            if (selectId!="")
            {
                HttpContext.Session.SetString("selectId", selectId);
                return RedirectToAction("Register_list");
            }
            else
            {
                return RedirectToAction("Register_locate");
            }
        }
        [HttpGet]
        public IActionResult Register_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register_list(List<Human_file_Model> list)
        {
            string selectId = HttpContext.Session.GetString("selectId");
            Dictionary<string, object> di = new Dictionary<string, object>();
            if (selectId == "1")
            {
                list = sgbll.HumanFileSelect().Where(e => e.First_kind_id == selectId && e.Check_status == 1).ToList();
                //查询一级机构下面子级机构人数
                var list2 = list.GroupBy(e=>new {e.First_kind_id,e.First_kind_name}).Select(e=>(new { Fid=e.Key.First_kind_id,Fname=e.Key.First_kind_name,count=e.Count(),salarysum=e.Sum(item=>item.Salary_sum)})).ToList();
                di["dt"] = list2;
                di["index"] = list2.Count;
                var Name = "I级机构";
                HttpContext.Session.SetString("JGName",Name);
            }
            else if (selectId == "2")
            {
                //查询二级机构下面子级机构人数
                list = sgbll.HumanFileSelect().Where(e => e.Second_kind_id == selectId && e.Check_status == 1).ToList();
                var list2 = list.GroupBy(e => new { e.Second_kind_id, e.Second_kind_name }).Select(e => (new { Fid = e.Key.Second_kind_id, Fname = e.Key.Second_kind_name, count = e.Count(), salarysum = e.Sum(item => item.Salary_sum) })).ToList();
                di["dt"] = list2;
                di["index"] = list2.Count;
                var Name = "II级机构";
                HttpContext.Session.SetString("JGName", Name);
            }
            else
            {
                //查询三级机构下面子级机构人数
                list = sgbll.HumanFileSelect().Where(e => e.Third_kind_id == selectId && e.Check_status == 1).ToList();
                var list2 = list.GroupBy(e => new { e.Third_kind_id, e.Third_kind_name }).Select(e => (new { Fid = e.Key.Third_kind_id, Fname = e.Key.Third_kind_name, count = e.Count(), salarysum = e.Sum(item => item.Salary_sum) })).ToList();
                di["dt"] = list2;
                di["index"] = list2.Count;
                var Name = "III级机构";
                HttpContext.Session.SetString("JGName", Name);
            }
            double Salary_sum = 0;
            double Paid_salary_sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                Salary_sum += list[i].Salary_sum;
                Paid_salary_sum += list[i].Paid_salary_sum;
            }
            di["JBMoney"] = Salary_sum;
            di["SFMoney"] = Paid_salary_sum;
            di["ZRen"] = list.Count;
            di["selectId"] = selectId;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpGet]
        public IActionResult Register_commit(string Fname)
        {
            Fname = Request.Query["Fname"];
            HttpContext.Session.SetString("Fname", Fname);
            return View();
        }
        //根据机构名称查询
        [HttpPost]
        public IActionResult Register_commit2(List<Human_file_Model> list)
        {
            Dictionary<string, object> di = new Dictionary<string, object>();
            List<Salary_grant_Model> sgm = new List<Salary_grant_Model>();
            string Fname = HttpContext.Session.GetString("Fname");
            string selectId = HttpContext.Session.GetString("selectId");
            if (selectId == "1")
            {
                list = sgbll.HumanFileSelect().Where(e => e.First_kind_name == Fname).ToList();
                sgm = sgbll.SalaryGrantSelect().Where(e => e.First_kind_name == Fname).ToList();
            }
            else if (selectId == "2")
            {
                list = sgbll.HumanFileSelect().Where(e => e.Second_kind_name == Fname).ToList();
                sgm = sgbll.SalaryGrantSelect().Where(e => e.Second_kind_name == Fname).ToList();
            }
            else
            {
                list = sgbll.HumanFileSelect().Where(e => e.Third_kind_name == Fname).ToList();
                sgm = sgbll.SalaryGrantSelect().Where(e => e.Third_kind_name == Fname).ToList();
            }
            di["dt"] = list;
            di["dg"] = sgm;
            di["Count"] = list.Count;
            di["Salary"] = list.Sum(e => e.Salary_sum);
            di["FName"] = Fname;
            string salaryid = list[0].Salary_standard_id;
            di["Salary_standard_id"] = salaryid;
            di["UName"] = HttpContext.Session.GetString("UName");
            //di["index"] = HttpContext.Session.GetString("index");
            return Content(JsonConvert.SerializeObject(di));
        }

        //薪酬发放标准单的详细模态框
        [HttpPost]
        public IActionResult Register_commit3(List<Salary_standard_details_Model> list)
        {
            string Salary_standard_id = Request.Form["Salary_standard_id"];
            list = ssdbll.Salary_standard_details_Select().Where(e => e.Standard_id == Salary_standard_id).ToList();
            return Content(JsonConvert.SerializeObject(list));
        }
        [HttpPost]
        public async Task<IActionResult> Register_commit(Salary_grant_Model salary_)
        {
            string[] Sgr_id = Request.Form["Sgr_id"];
            string[] salaryPaidSum = Request.Form["SalaryPaidSum"];
            string[] Human_id = Request.Form["Human_id"];
            string[] Human_name = Request.Form["Human_name"];
            string[] bounsSum = Request.Form["bounsSum"];
            string[] saleSum = Request.Form["saleSum"];
            string[] deductSum = Request.Form["deductSum"];
            string[] Salary_grant_id = Request.Form["Salary_grant_id"];
            //string salaryStandardSum = Request.Form["salary_paid_sum"];
            int result = 0;
            for (int i = 0; i < salaryPaidSum.Length; i++)
            {
                salary_.Salary_paid_sum = Convert.ToDouble(salaryPaidSum[i]);
                salary_.Salary_standard_sum = Convert.ToDouble(salaryPaidSum[i]);
                salary_.Sgr_id = Convert.ToInt32(Sgr_id[i]);
                result = await sgbll.SalaryGrantUp(salary_);
                Salary_grant_details_Model details = new Salary_grant_details_Model()
                {
                    Salary_grant_id = Salary_grant_id[i],
                    Human_id=Human_id[i],
                    Human_name=Human_name[i],
                    Bouns_sum=Convert.ToDouble(bounsSum[i]),
                    Sale_sum=Convert.ToDouble(saleSum[i]),
                    Deduct_sum = Convert.ToDouble(deductSum[i]),
                    Salary_standard_sum= Convert.ToDouble(salaryPaidSum[i]),
                    Salary_paid_sum= Convert.ToDouble(salaryPaidSum[i]),
                };
                result = await sgdbll.Salary_grant_detailAdd(details);
            }
            if (result>0)
            {
                return RedirectToAction("Register_success");
            }
            else
            {
                return RedirectToAction("Register_list");
            }
        }
        public IActionResult Register_success()
        {
            return View();
        }
        #endregion

        #region 薪酬发放登记复核
        [HttpGet]
        public IActionResult Check_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Check_list(FenYeModel fen)
        {
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = " Check_status=0";
            fen.KeyName = "Sgr_id";
            fen.TableName = "Salary_grant";
            List<Salary_grant_Model> page = sgbll.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpGet]
        public IActionResult Check(string Salary_grant_id) 
        {
            Salary_grant_id = Request.Query["Salary_grant_id"];
            string Salary_standard_id = Request.Query["Salary_standard_id"];
            HttpContext.Session.SetString("Salary_grant_id", Salary_grant_id);
            HttpContext.Session.SetString("Salary_standard_id", Salary_standard_id);
            return View();
        }
        [HttpPost]
        public IActionResult Check()
        {
            string Salary_grant_id= HttpContext.Session.GetString("Salary_grant_id");
            string Salary_standard_id = HttpContext.Session.GetString("Salary_standard_id");
            List<Salary_grant_details_Model> list = sgdbll.Salary_grant_detailSelect().Where(e => e.Salary_grant_id == Salary_grant_id).ToList();
            List<Salary_grant_Model> sgm = sgbll.SalaryGrantSelect().Where(e => e.Salary_standard_id == Salary_standard_id).ToList();
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["dg"] = sgm;
            di["Count"] = list.Count;
            di["Salary"] = list.Sum(e=>e.Salary_paid_sum);
            di["UName"] = HttpContext.Session.GetString("UName");
            di["Salary_grant_id"] = Salary_grant_id;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpPost]
        public IActionResult Check2(List<Salary_standard_details_Model> list)
        {
            string Salary_standard_id = HttpContext.Session.GetString("Salary_standard_id");
            list = ssdbll.Salary_standard_details_Select().Where(e => e.Standard_id == Salary_standard_id).ToList();
            return Content(JsonConvert.SerializeObject(list));
        }
        [HttpPost]
        public async Task<IActionResult> Check3(Salary_grant_Model salary) 
        {
            int Grd_id =Convert.ToInt32(Request.Form["Grd_id"]);
            double bounsSum =Convert.ToDouble(Request.Form["bounsSum"]);
            double saleSum = Convert.ToDouble(Request.Form["saleSum"]);
            double deductSum = Convert.ToDouble(Request.Form["deductSum"]);
            double SalaryPaidSum = Convert.ToDouble(Request.Form["SalaryPaidSum"]);

            int Sgr_id = Convert.ToInt32(Request.Form["Sgr_id"]);
            string checker = Request.Form["checker"];
            DateTime checkerTime = Convert.ToDateTime(Request.Form["checkerTime"]);
            int result = 0;
            Salary_grant_details_Model details_Model = new Salary_grant_details_Model()
            {
                Grd_id = Grd_id,
                Bouns_sum = bounsSum,
                Sale_sum = saleSum,
                Deduct_sum = deductSum,
                Salary_paid_sum = SalaryPaidSum,
                Salary_standard_sum = SalaryPaidSum
            };
            result = await sgdbll.SalaryGrantDetailUpdate(details_Model);
            salary = new Salary_grant_Model()
            {
                Sgr_id = Sgr_id,
                Checker = checker,
                Check_status = 1,
                Check_time = checkerTime,
                Salary_paid_sum = SalaryPaidSum,
                Salary_standard_sum = SalaryPaidSum
            };
            result = await sgbll.SalaryGrantUpdate(salary);
            if (result>0)
            {
                return RedirectToAction("Check_success");
            }
            else
            {
                return RedirectToAction("Check_list");
            }
        }
        public IActionResult Check_success()
        {
            return View();
        }

        #endregion

        #region 薪酬发放查询 
        [HttpGet]
        public IActionResult Query_locate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Query_locate(string salaryGrantId)
        {
            salaryGrantId = Request.Form["Salary_standard_id"];
            string primarKey = Request.Form["First_kind_name"];
            HttpContext.Session.SetString("salaryGrantId", salaryGrantId);
            HttpContext.Session.SetString("primarKey", primarKey);
            string startDate = Request.Form["startDate"];
            string endDate = Request.Form["endDate"];
            DateTime dateTime = DateTime.Now;
            DateTime dateTime1 = Convert.ToDateTime(startDate + "-" + endDate + "-" + dateTime.Day);
            HttpContext.Session.SetString("dateTime", dateTime1.ToString());
            return RedirectToAction("Query_list");

        }

        [HttpGet]
        public IActionResult Query_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Query_list(FenYeModel fenYe)
        {
            string salaryGrantId = HttpContext.Session.GetString("salaryGrantId");
            string primarKey = HttpContext.Session.GetString("primarKey");
            DateTime dateTime =Convert.ToDateTime(HttpContext.Session.GetString("dateTime"));
            List<Salary_grant_Model> list = sgbll.SalaryGrantSelect();
            string where = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (primarKey == list[i].First_kind_name)
                {
                    where = $@" Check_status=1 and Salary_standard_id like '%{salaryGrantId}%' and First_kind_name like '%{primarKey}%' and Check_time > '{dateTime}'";
                }
                else if (primarKey == list[i].Second_kind_name)
                {
                    where = $@" Check_status=1 and Salary_standard_id like '%{salaryGrantId}%' and Second_kind_name like '%{primarKey}%' and Check_time > '{dateTime}'";
                }
                else if (primarKey == list[i].Third_kind_name)
                {
                    where = $@" Check_status=1 and Salary_standard_id like '%{salaryGrantId}%' and Third_kind_name like '%{primarKey}%' and Check_time > '{dateTime}'";
                }
            }
            string currentPage = Request.Form["currentPage"];
            fenYe.CurrentPage = int.Parse(currentPage.ToString());
            fenYe.PageSize = 3;
            fenYe.Where = where;
            fenYe.KeyName = "Sgr_id";
            fenYe.TableName = "Salary_grant";
            List<Salary_grant_Model> page = sgbll.FenYe(fenYe);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fenYe.Pages;
            di["rows"] = fenYe.Rows;
            di["PageSize"] = fenYe.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }

        [HttpGet]
        public IActionResult Query(string Salary_grant_id)
        {
            Salary_grant_id = Request.Query["Salary_grant_id"];
            HttpContext.Session.SetString("Salary_grant_id", Salary_grant_id);
            string Salary_standard_id = Request.Query["Salary_standard_id"];
            HttpContext.Session.SetString("Salary_standard_id", Salary_standard_id);
            return View();
        }

        [HttpPost]
        public IActionResult Query() 
        {
            string Salary_grant_id = HttpContext.Session.GetString("Salary_grant_id");
            string Salary_standard_id = HttpContext.Session.GetString("Salary_standard_id");           
            List<Salary_grant_details_Model> list = sgdbll.Salary_grant_detailSelect().Where(e => e.Salary_grant_id == Salary_grant_id).ToList();
            List<Salary_grant_Model> list2 = sgbll.SalaryGrantSelect().Where(e => e.Salary_standard_id == Salary_standard_id).ToList();
            Dictionary<string, object> di = new Dictionary<string, object>();
            for (int i = 0; i < list2.Count; i++)
            {
                if (list2[i].Second_kind_name==""||list2[i].Third_kind_name=="")
                {
                    di["SName"] = list2[i].First_kind_name;
                }
                else if (list2[i].Third_kind_name == "")
                {
                    di["SName"] = list2[i].Second_kind_name;
                }
                else
                {
                    di["SName"] = list2[i].Third_kind_name;
                }
            }
            di["dt"] = list;
            di["dg"] = list2;
            di["Count"] = list.Count;
            di["Salary"] = list.Sum(e => e.Salary_paid_sum);
            di["Salary_standard_id"] = Salary_standard_id;
            return Content(JsonConvert.SerializeObject(di));
        }
       
        [HttpPost]
        public IActionResult Query2(List<Salary_standard_details_Model> list)
        {
            string Salary_standard_id = HttpContext.Session.GetString("Salary_standard_id");
            var result = ssdbll.Salary_standard_details_Select().Where(e => e.Standard_id == Salary_standard_id)
                .Select(e => new { Item_name=e.Item_name, Salary=e.Salary }).ToList();
            return Content(JsonConvert.SerializeObject(result));
        }
        public IActionResult LLLL() 
        {
            return View();
        }
        #endregion
    }
}