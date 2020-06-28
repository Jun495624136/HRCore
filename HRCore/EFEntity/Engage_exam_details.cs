using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    //    /* 创建新表 engage_exam_details。                                                                */
    ///* engage_exam_details : 试卷详细信息                                                             */
    ///* 	exd_id : 主键，自动增长列                                                                       */
    ///* 	exam_number : 试卷编号                                                                      */
    ///* 	first_kind_id : 试题一级分类编号                                                                */
    ///* 	first_kind_name : 试题一级分类名称                                                              */
    ///* 	second_kind_id : 试题二级分类编号                                                               */
    ///* 	second_kind_name : 试题二级分类名称                                                             */
    ///* 	question_amount : 出题数量  
   public class Engage_exam_details
    {
        [Key]
        public int Exd_id { get; set; }
        public string Exam_number { get; set; }
        public string First_kind_id { get; set; }
        public string First_kind_name { get; set; }
        public string Second_kind_id { get; set; }
        public string Second_kind_name { get; set; }
        public int Question_amount { get; set; }
    }
}
