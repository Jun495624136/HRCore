using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using IBLL;
using System.Threading.Tasks;

namespace BLL
{
    public class Salary_grantBLL : ISalary_grantBLL
    {
        private readonly ISalary_grantDAO grantDAO;
        public Salary_grantBLL(ISalary_grantDAO grantDAO) 
        {
            this.grantDAO = grantDAO;
        }

        public List<Salary_grant_Model> FenYe(FenYeModel fenYe)
        {
            return grantDAO.FenYe(fenYe);
        }

        public List<Human_file_Model> HumanFileSelect()
        {
            return grantDAO.HumanFileSelect();
        }

        public List<Salary_grant_Model> SalaryGrantSelect()
        {
            return grantDAO.SalaryGrantSelect();
        }

        public Task<int> SalaryGrantUp(Salary_grant_Model salary)
        {
            return grantDAO.SalaryGrantUp(salary);
        }

        public Task<int> SalaryGrantUpdate(Salary_grant_Model salary)
        {
            return grantDAO.SalaryGrantUpdate(salary);
        }
    }
}
