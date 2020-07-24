using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class Salary_standard_details_DAO : ISalary_standard_details_DAO
    {
        private readonly HR_DBContext dBContext;
        public Salary_standard_details_DAO(HR_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<int> ISalary_standard_details_Add(Salary_standard_details_Model _Details)
        {
            try
            {
                Salary_standard_details salary_ = new Salary_standard_details()
                {
                    Standard_id = _Details.Standard_id,
                    Standard_name = _Details.Standard_name,
                    Item_id = _Details.Item_id,
                    Item_name = _Details.Item_name,
                    Salary = _Details.Salary
                };
                dBContext.Salary_standard_detailss.Add(salary_);
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_standard_details_DAO",e);
            }
            return await dBContext.SaveChangesAsync();
        }

        public List<Salary_standard_details_Model> Salary_standard_details_Select()
        {
            List<Salary_standard_details> salary_Standard_s = dBContext.Salary_standard_detailss.ToList();
            List<Salary_standard_details_Model> standard_Details_Models = new List<Salary_standard_details_Model>();
            try
            {
                foreach (Salary_standard_details item in salary_Standard_s)
                {
                    Salary_standard_details_Model salary_Standard_ = new Salary_standard_details_Model()
                    {
                        Sdt_id = item.Sdt_id,
                        Standard_id = item.Standard_id,
                        Standard_name = item.Standard_name,
                        Item_id = item.Item_id,
                        Item_name = item.Item_name,
                        Salary = item.Salary
                    };
                    standard_Details_Models.Add(salary_Standard_);
                }
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_standard_details_DAO", e); ;
            }
            return standard_Details_Models;
        }

        public async Task<int> Salary_standard_details_Update(Salary_standard_details_Model _Details)
        {
            try
            {
                Salary_standard_details _Details1 = new Salary_standard_details()
                {
                    Salary = _Details.Salary,
                    Standard_name = _Details.Standard_name,
                    Sdt_id = _Details.Sdt_id
                };
                dBContext.Salary_standard_detailss.Attach(_Details1);
                //db.Entry(_Details1).State = System.Data.Entity.EntityState.Modified;
                dBContext.Entry(_Details1).Property(e => e.Salary).IsModified = true;
                dBContext.Entry(_Details1).Property(e => e.Standard_name).IsModified = true;
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_standard_details_DAO", e);
            }
            return await dBContext.SaveChangesAsync();
        }
    }
}
