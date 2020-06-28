using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    //    /* 创建新表 major_change。                                                                       */
    ///* major_change : 职位调动表                                                                     */
    ///* 	mch_id : 主键，自动增长列                                                                       */
    ///* 	first_kind_id : 一级机构编号                                                                  */
    ///* 	first_kind_name : 一级机构名称                                                                */
    ///* 	second_kind_id : 二级机构编号                                                                 */
    ///* 	second_kind_name : 二级机构名称                                                               */
    ///* 	third_kind_id : 三级机构编号                                                                  */
    ///* 	third_kind_name : 三级机构名称                                                                */
    ///* 	major_kind_id : 职位分类编号                                                                  */
    ///* 	major_kind_name : 职位分类名称                                                                */
    ///* 	major_id : 职位编号                                                                         */
    ///* 	major_name : 职位名称                                                                       */
    ///* 	new_first_kind_id : 新一级机构编号                                                             */
    ///* 	new_first_kind_name : 新一级机构名称                                                           */
    ///* 	new_second_kind_id : 新二级机构编号                                                            */
    ///* 	new_second_kind_name : 新二级机构名称                                                          */
    ///* 	new_third_kind_id : 新三级机构编号                                                             */
    ///* 	new_third_kind_name : 新三级机构名称                                                           */
    ///* 	new_major_kind_id : 新职位分类编号                                                             */
    ///* 	new_major_kind_name : 新职位分类名称                                                           */
    ///* 	new_major_id : 新职位编号                                                                    */
    ///* 	new_major_name : 新职位名称                                                                  */
    ///* 	human_id : 人力资源档案编号                                                                     */
    ///* 	human_name : 姓名                                                                         */
    ///* 	salary_standard_id : 薪酬标准编号                                                             */
    ///* 	salary_standard_name : 薪酬标准名称                                                           */
    ///* 	salary_sum : 薪酬总额                                                                       */
    ///* 	new_salary_standard_id : 新薪酬标准编号                                                        */
    ///* 	new_salary_standard_name : 新薪酬标准名称                                                      */
    ///* 	new_salary_sum : 新薪酬总额                                                                  */
    ///* 	change_reason : 调动原因                                                                    */
    ///* 	check_reason : 审核通过意见                                                                   */
    ///* 	check_status : 复核通过状态                                                                   */
    ///* 	register : 登记人                                                                          */
    ///* 	checker : 复核人                                                                           */
    ///* 	regist_time : 登记时间                                                                      */
    ///* 	check_time : 复核时间          
   public class Major_change
    {
        [Key]
        public int Mch_id { get; set; }
        public string First_kind_id { get; set; }
        public string First_kind_name { get; set; }
        public string Second_kind_id { get; set; }
        public string Second_kind_name { get; set; }
        public string Third_kind_id { get; set; }
        public string Third_kind_name { get; set; }
        public string Major_kind_id { get; set; }
        public string Major_kind_name { get; set; }
        public string Major_id { get; set; }
        public string Major_name { get; set; }
        public string New_first_kind_id { get; set; }
        public string New_first_kind_name { get; set; }
        public string New_second_kind_id { get; set; }
        public string New_second_kind_name { get; set; }
        public string New_third_kind_id { get; set; }
        public string New_third_kind_name { get; set; }
        public string New_major_kind_id { get; set; }
        public string New_major_kind_name { get; set; }
        public string New_major_id { get; set; }
        public string New_major_name { get; set; }
        public string Human_id { get; set; }
        public string Human_name { get; set; }
        public string Salary_standard_id { get; set; }
        public string Salary_standard_name { get; set; }
        public double Salary_sum { get; set; }
        public string New_salary_standard_id { get; set; }
        public string New_salary_standard_name { get; set; }
        public double New_salary_sum { get; set; }
        public string Change_reason { get; set; }
        public string Check_reason { get; set; }
        public int Check_status { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public DateTime Regist_time { get; set; }
        public DateTime Check_time { get; set; }
    }
}
