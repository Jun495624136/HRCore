using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    //    /* 创建新表 salary_grant。                                                                       */
    ///* salary_grant : 薪酬发放登记表  ***************M                                                                 */
    ///* 	sgr_id : 主键，自动增长列                                                                       */
    ///* 	salary_grant_id : 薪酬发放编号                                                                */
    ///* 	salary_standard_id : 薪酬标准单编号                                                            */
    ///* 	first_kind_id : 一级机构编号                                                                  */
    ///* 	first_kind_name : 一级机构名称                                                                */
    ///* 	second_kind_id : 二级机构编号                                                                 */
    ///* 	second_kind_name : 二级机构名称                                                               */
    ///* 	third_kind_id : 三级机构编号                                                                  */
    ///* 	third_kind_name : 三级机构名称                                                                */
    ///* 	human_amount : 总人数                                                                      */
    ///* 	salary_standard_sum : 标准薪酬总金额                                                           */
    ///* 	salary_paid_sum : 实发总金额                                                                 */
    ///* 	register : 登记人                                                                          */
    ///* 	regist_time : 登记时间                                                                      */
    ///* 	checker : 复核人                                                                           */
    ///* 	check_time : 复核时间                                                                       */
    ///* 	check_status : 复核状态 
   public class Salary_grant
    {
        [Key]
        public int Sgr_id { get; set; }
        public string Salary_grant_id { get; set; }
        public string Salary_standard_id { get; set; }
        public string First_kind_id { get; set; }
        public string First_kind_name { get; set; }
        public string Second_kind_id { get; set; }
        public string Second_kind_name { get; set; }
        public string Third_kind_id { get; set; }
        public string Third_kind_name { get; set; }
        public int Human_amount { get; set; }
        public double Salary_standard_sum { get; set; }
        public double Salary_paid_sum { get; set; }
        public string Register { get; set; }
        public DateTime Regist_time { get; set; }
        public string Checker { get; set; }
        public DateTime Check_time { get; set; }
        public int Check_status { get; set; }
    }
}
