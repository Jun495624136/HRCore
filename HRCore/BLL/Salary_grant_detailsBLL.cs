using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using IBLL;
using Model;
using System.Threading.Tasks;

namespace BLL
{
    public class Salary_grant_detailsBLL : ISalary_grant_detailsBLL
    {
        private readonly ISalary_grant_detailsDAO salary_Grant_Details;
        public Salary_grant_detailsBLL(ISalary_grant_detailsDAO salary_Grant_Details)
        {
            this.salary_Grant_Details = salary_Grant_Details;
        }

        public Task<int> SalaryGrantDetailUpdate(Salary_grant_details_Model salary_Grant_)
        {
            return salary_Grant_Details.SalaryGrantDetailUpdate(salary_Grant_);
        }

        public Task<int> Salary_grant_detailAdd(Salary_grant_details_Model salary_Grant)
        {
            return salary_Grant_Details.Salary_grant_detailAdd(salary_Grant);
        }

        public List<Salary_grant_details_Model> Salary_grant_detailSelect()
        {
            return salary_Grant_Details.Salary_grant_detailSelect();
        }
    }
}
