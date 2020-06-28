using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //    /* 创建新表 salary_standard。                                                                    */
    ///* salary_standard : 薪酬标准基本信息表     ***********************M                                                         */
    ///* 	ssd_id : 主键，自动增长列                                                                       */
    ///* 	standard_id : 薪酬标准单编号                                                                   */
    ///* 	standard_name : 薪酬标准单名称                                                                 */
    ///* 	designer : 制定者名字                                                                        */
    ///* 	register : 登记人                                                                          */
    ///* 	checker : 复核人                                                                           */
    ///* 	changer : 变更人                                                                           */
    ///* 	regist_time : 登记时间                                                                      */
    ///* 	check_time : 复核时间                                                                       */
    ///* 	change_time : 变更时间                                                                      */
    ///* 	salary_sum : 薪酬总额                                                                       */
    ///* 	check_status : 是否经过复核                                                                   */
    ///* 	change_status : 更改状态                                                                    */
    ///* 	check_comment : 复核意见                                                                   */
    ///* 	remark : 备注
   public class Salary_standard_Model
    {
        [Key]
        public int Ssd_id { get; set; }
        public string Standard_id { get; set; }
        [Required(ErrorMessage = "薪酬标准单名称不能为空")]
        public string Standard_name { get; set; }
        [Required(ErrorMessage = "制定人不能为空")]
        public string Designer { get; set; }
        [Required(ErrorMessage = "登记人不能为空")]
        public string Register { get; set; }
        [Required(ErrorMessage = "复核人不能为空")]
        public string Checker { get; set; }
        [Required(ErrorMessage = "变更人不能为空")]
        public string Changer { get; set; }
        public DateTime Regist_time { get; set; }
        public DateTime Check_time { get; set; }
        public DateTime Change_time { get; set; }
        public double Salary_sum { get; set; }
        public int Check_status { get; set; }
        public int Change_status { get; set; }
        [Required(ErrorMessage = "复核建议不能为空")]
        public string Check_comment { get; set; }
        public string Remark { get; set; }
    }
}
