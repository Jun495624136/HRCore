using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFEntity;
using IDAO;
using Model;
namespace DAO
{
    public class Salary_grant_detailsDAO : ISalary_grant_detailsDAO
    {
        private readonly HR_DBContext dBContext;
        public Salary_grant_detailsDAO(HR_DBContext dBContext) 
        {
            this.dBContext = dBContext;
        }

        public async Task<int> SalaryGrantDetailUpdate(Salary_grant_details_Model salary_Grant_)
        {
            try
            {
                Salary_grant_details details = new Salary_grant_details() 
                {
                    Grd_id= salary_Grant_.Grd_id,
                    Bouns_sum=salary_Grant_.Bouns_sum,
                    Sale_sum=salary_Grant_.Sale_sum,
                    Deduct_sum=salary_Grant_.Deduct_sum,
                    Salary_paid_sum=salary_Grant_.Salary_paid_sum,
                    Salary_standard_sum=salary_Grant_.Salary_standard_sum
                };
                dBContext.Salary_grant_detailss.Attach(details);
                dBContext.Entry(details).Property(e => e.Bouns_sum).IsModified = true;
                dBContext.Entry(details).Property(e => e.Sale_sum).IsModified = true;
                dBContext.Entry(details).Property(e => e.Deduct_sum).IsModified = true;
                dBContext.Entry(details).Property(e => e.Salary_paid_sum).IsModified = true;
                dBContext.Entry(details).Property(e => e.Salary_standard_sum).IsModified = true;
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_grant_detailsDAO", e);
            }
            return await dBContext.SaveChangesAsync();
        }

        public async Task<int> Salary_grant_detailAdd(Salary_grant_details_Model salary_Grant)
        {
            try
            {
                Salary_grant_details details = new Salary_grant_details()
                {
                    Salary_grant_id = salary_Grant.Salary_grant_id,
                    Salary_paid_sum = salary_Grant.Salary_paid_sum,
                    Salary_standard_sum = salary_Grant.Salary_standard_sum,
                    Sale_sum = salary_Grant.Sale_sum,
                    Bouns_sum = salary_Grant.Bouns_sum,
                    Deduct_sum = salary_Grant.Deduct_sum,
                    Human_id = salary_Grant.Human_id,
                    Human_name = salary_Grant.Human_name
                };
                dBContext.Salary_grant_detailss.Add(details);
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_grant_detailsDAO", e);
            }
            return await dBContext.SaveChangesAsync();
        }

        public List<Salary_grant_details_Model> Salary_grant_detailSelect()
        {
            List<Salary_grant_details_Model> list = new List<Salary_grant_details_Model>();
            try
            {
                List<Salary_grant_details> list2 = dBContext.Salary_grant_detailss.ToList();
                foreach (var item in list2)
                {
                    Salary_grant_details_Model salary_Grant_Details_ = new Salary_grant_details_Model() 
                    {
                        Grd_id=item.Grd_id,
                        Salary_grant_id=item.Salary_grant_id,
                        Salary_paid_sum=item.Salary_paid_sum,
                        Salary_standard_sum=item.Salary_standard_sum,
                        Sale_sum=item.Sale_sum,
                        Bouns_sum=item.Bouns_sum,
                        Deduct_sum=item.Deduct_sum,
                        Human_id=item.Human_id,
                        Human_name=item.Human_name
                    };
                    list.Add(salary_Grant_Details_);
                }
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_grant_detailsDAO", e);
            }
            return list;
        }
    }
}
