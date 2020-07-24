using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class Salary_standardModeDAO: Salary_standardModelIDAO
    {
        private readonly HR_DBContext coreDbContext;
        public Salary_standardModeDAO(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Salary_standard_Model> Select()
        {
            List<Salary_standard> list = coreDbContext.Salary_standards.ToList();
            List<Salary_standard_Model> list2 = new List<Salary_standard_Model>();
            //需要把ED->DTO
            foreach (Salary_standard item in list)
            {
                Salary_standard_Model bjm = new Salary_standard_Model()
                {
                    Ssd_id = item.Ssd_id,
                    Standard_id = item.Standard_id,
                    Standard_name = item.Standard_name,
                    Designer = item.Designer,
                    Register = item.Register,
                    Checker = item.Checker,
                    Changer = item.Changer,
                    Regist_time = item.Regist_time,
                    Check_time = item.Check_time,
                    Change_time = item.Change_time,
                    Check_status = item.Check_status,
                    Change_status = item.Change_status,
                    Check_comment = item.Check_comment,
                    Salary_sum = item.Salary_sum,
                    Remark = item.Remark
                };
                list2.Add(bjm);
            }
            return list2;
        }
    }
}
