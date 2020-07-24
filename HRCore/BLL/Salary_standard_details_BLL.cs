using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class Salary_standard_details_BLL : ISalary_standard_details_BLL
    {
        private readonly ISalary_standard_details_DAO ssddao;
        public Salary_standard_details_BLL(ISalary_standard_details_DAO ssddao) 
        {
            this.ssddao = ssddao;
        }
        public Task<int> ISalary_standard_details_Add(Salary_standard_details_Model _Details)
        {
            return ssddao.ISalary_standard_details_Add(_Details);
        }

        public List<Salary_standard_details_Model> Salary_standard_details_Select()
        {
            return ssddao.Salary_standard_details_Select();
        }

        public Task<int> Salary_standard_details_Update(Salary_standard_details_Model _Details)
        {
            return ssddao.Salary_standard_details_Update(_Details);
        }
    }
}
