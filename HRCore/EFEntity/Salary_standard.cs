using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
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
   public class Salary_standard
    {
        [Key]
        public int Ssd_id { get; set; }
        public string Standard_id { get; set; }
        public string Standard_name { get; set; }
        public string Designer { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public string Changer { get; set; }
        public DateTime Regist_time { get; set; }
        public DateTime Check_time { get; set; }
        public DateTime Change_time { get; set; }
        public double Salary_sum { get; set; }
        public int Check_status { get; set; }
        public int Change_status { get; set; }
        public string Check_comment { get; set; }
        public string Remark { get; set; }
    }
}
