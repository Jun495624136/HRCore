using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    //    /* 创建新表 training。                                                                           */
    ///* training : 培训登记表                                                                         */
    ///* 	tra_id : 主键，自动增长列                                                                       */
    ///* 	major_kind_id : 职位分类编号                                                                  */
    ///* 	major_kind_name : 职位分类名称                                                                */
    ///* 	major_id : 职位名称                                                                         */
    ///* 	major_name : 职位名称                                                                       */
    ///* 	human_id : 人力资源档案编号                                                                     */
    ///* 	human_name : 姓名                                                                         */
    ///*	training_item ：培训项目										*/
    ///* 	training_time : 培训时间                                                                    */
    ///* 	training_hour : 培训课时                                                                    */
    ///* 	training_degree : 培训成绩等级                                                                */
    ///* 	register : 登记人                                                                          */
    ///* 	checker : 复核人                                                                           */
    ///* 	regist_time : 登记时间                                                                      */
    ///* 	check_time : 复核时间                                                                       */
    ///* 	checkstatus : 培训复核状态                                                                    */
    ///* 	remark : 备注   
   public class Training
    {
        [Key]
        public int Tra_id { get; set; }
        public string Major_kind_id { get; set; }
        public string Major_kind_name { get; set; }
        public string Major_id { get; set; }
        public string Major_name { get; set; }
        public string Human_id { get; set; }
        public string Human_name { get; set; }
        public string Training_item { get; set; }
        public DateTime Training_time { get; set; }
        public int Training_hour { get; set; }
        public string Training_degree { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public DateTime Regist_time { get; set; }
        public DateTime Check_time { get; set; }
        public int Checkstatus { get; set; }
        public string Remark { get; set; }
    }
}
