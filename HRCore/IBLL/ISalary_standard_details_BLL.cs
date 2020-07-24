using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface ISalary_standard_details_BLL
    {
        /// <summary>
        /// 薪酬标准单详细信息添加
        /// </summary>
        /// <param name="_Details"></param>
        /// <returns></returns>
        Task<int> ISalary_standard_details_Add(Salary_standard_details_Model _Details);
        /// <summary>
        /// 薪酬标准单详细信息查询
        /// </summary>
        /// <returns></returns>
        List<Salary_standard_details_Model> Salary_standard_details_Select();
        /// <summary>
        /// 薪酬标准单详细信息修改
        /// </summary>
        /// <param name="_Details"></param>
        /// <returns></returns>
        Task<int> Salary_standard_details_Update(Salary_standard_details_Model _Details);
    }
}
