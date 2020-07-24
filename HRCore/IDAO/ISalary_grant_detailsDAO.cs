using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
    public interface ISalary_grant_detailsDAO
    {
        /// <summary>
        /// 薪酬发放详细信息查询      
        /// </summary>
        /// <returns></returns>
        List<Salary_grant_details_Model> Salary_grant_detailSelect();
        /// <summary>
        /// 薪酬发放详细信息增加
        /// </summary>
        /// <param name="salary_Grant"></param>
        /// <returns></returns>
        Task<int> Salary_grant_detailAdd(Salary_grant_details_Model salary_Grant);
        /// <summary>
        /// 薪酬发放复核修改
        /// </summary>
        /// <returns></returns>
        Task<int> SalaryGrantDetailUpdate(Salary_grant_details_Model salary_Grant_);
    }
}
