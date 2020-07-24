using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface ISalary_grantBLL
    {
        /// <summary>
        /// 薪酬发放登记查询
        /// </summary>
        /// <returns></returns>
        List<Salary_grant_Model> SalaryGrantSelect();
        /// <summary>
        /// 薪酬发放登记查询(人力资源档案表)
        /// </summary>
        /// <returns></returns>
        List<Human_file_Model> HumanFileSelect();
        /// <summary>
        /// 薪酬发放登记修改实发金额
        /// </summary>
        /// <returns></returns>
        Task<int> SalaryGrantUp(Salary_grant_Model salary);
        /// <summary>
        /// 薪酬发放登记复核分页
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        List<Salary_grant_Model> FenYe(FenYeModel fenYe);
        /// <summary>
        /// 薪酬发放复核修改
        /// </summary>
        /// <returns></returns>
        Task<int> SalaryGrantUpdate(Salary_grant_Model salary);
    }
}
