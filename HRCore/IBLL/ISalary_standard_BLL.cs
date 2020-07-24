using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface ISalary_standard_BLL
    {
        /// <summary>
        /// 薪酬标准登记添加
        /// </summary>
        /// <param name="salary_"></param>
        /// <returns></returns>
        Task<int> Salary_standard_Add(Salary_standard_Model salary_);
        /// <summary>
        /// 薪酬标准复核分页
        /// </summary>
        /// <returns></returns>
        List<Salary_standard_Model> FenYe(FenYeModel fen);
        /// <summary>
        /// 薪酬标准查询
        /// </summary>
        /// <returns></returns>
        List<Salary_standard_Model> Salary_standard_Select();

        /// <summary>
        /// 薪酬标准复核修改
        /// </summary>
        /// <param name="salary_"></param>
        /// <returns></returns>
        Task<int> Salary_standard_CheckerUpdate(Salary_standard_Model salary_);
        /// <summary>
        /// 薪酬标准变更修改
        /// </summary>
        /// <param name="salary_"></param>
        /// <returns></returns>
        Task<int> Salary_standard_Update(Salary_standard_Model salary_);
    }
}
