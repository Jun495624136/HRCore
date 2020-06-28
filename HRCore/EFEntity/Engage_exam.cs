using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    //    /* 创建新表 engage_exam。                                                                        */
    ///* engage_exam : 试卷登记表                                                                      */
    ///* 	exa_id : 主键，自动增长列                                                                       */
    ///* 	exam_number : 试卷编号                                                                      */
    ///* 	major_kind_id : 职位分类编号                                                                  */
    ///* 	major_kind_name : 职位分类名称                                                                */
    ///* 	major_id : 职位编号                                                                         */
    ///* 	major_name : 职位名称                                                                       */
    ///* 	register : 登记人                                                                          */
    ///* 	regist_time : 登记时间                                                                      */
    ///* 	limite_time : 答题限时  
   public class Engage_exam
    {
        [Key]
        public int Exa_id { get; set; }
        public string Exam_number { get; set; }
        public string Major_kind_id { get; set; }
        public string Major_kind_name { get; set; }
        public string Major_id { get; set; }
        public string Major_name { get; set; }
        public string Register { get; set; }
        public DateTime Regist_time { get; set; }
        public int Limite_time { get; set; }

    }
}
