using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    //    /* 创建新表 salary_grant_details。                                                               */
    ///* salary_grant_details : 薪酬发放详细信息                                                          */
    ///* 	grd_id : 主键，自动增长列                                                                       */
    ///* 	salary_grant_id : 薪酬发放编号                                                                */
    ///* 	human_id : 档案编号                                                                         */
    ///* 	human_name : 姓名                                                                         */
    ///* 	bouns_sum : 奖励金额                                                                        */
    ///* 	sale_sum : 销售绩效金额                                                                       */
    ///* 	deduct_sum : 应扣金额                                                                       */
    ///* 	salary_standard_sum : 标准薪酬总额                                                            */
    ///* 	salary_paid_sum : 实发薪酬总额 
   public class Salary_grant_details
    {
        [Key]
        public int Grd_id { get; set; }
        public string Salary_grant_id { get; set; }
        public string Human_id { get; set; }
        public string Human_name { get; set; }
        public double Bouns_sum { get; set; }
        public double Sale_sum { get; set; }
        public double Deduct_sum { get; set; }
        public double Salary_standard_sum { get; set; }
        public double Salary_paid_sum { get; set; }
    }
}
