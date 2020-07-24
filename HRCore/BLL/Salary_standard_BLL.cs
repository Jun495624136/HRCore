using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using IBLL;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class Salary_standard_BLL : ISalary_standard_BLL
    {
        public readonly ISalary_standard_DAO salaryDao;
        public Salary_standard_BLL(ISalary_standard_DAO salaryDao) 
        {
            this.salaryDao = salaryDao;
        }

        public List<Salary_standard_Model> FenYe(FenYeModel fen)
        {
            return salaryDao.FenYe(fen);
        }

        public Task<int> Salary_standard_Add(Salary_standard_Model salary_)
        {
            return salaryDao.Salary_standard_Add(salary_);
        }

        public Task<int> Salary_standard_CheckerUpdate(Salary_standard_Model salary_)
        {
            return salaryDao.Salary_standard_CheckerUpdate(salary_);
        }

        public List<Salary_standard_Model> Salary_standard_Select()
        {
            return salaryDao.Salary_standard_Select();
        }

        public Task<int> Salary_standard_Update(Salary_standard_Model salary_)
        {
            return salaryDao.Salary_standard_Update(salary_);
        }
    }
}
