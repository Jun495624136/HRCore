using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    //    /* 创建新表 engage_answer。                                                                      */
    ///* engage_answer : 考试答题登记表                                                                  */
    ///* 	ans_id : 主键，自动增长列                                                                       */
    ///* 	answer_number : 答案编号                                                                    */
    ///* 	exam_number : 试卷编号                                                                      */
    ///* 	resume_id : 简历编号                                                                      */
    ///* 	interview_id : 面试编号                                                                      */
    ///* 	human_name : 姓名                                                                         */
    ///* 	human_idcard : 身份证号                                                                     */
    ///* 	major_kind_id : 职位分类编号                                                                  */
    ///* 	major_kind_name : major_kind_name 属于 engage_answer                                      */
    ///* 	major_id : major_id 属于 engage_answer                                                    */
    ///* 	major_name : major_name 属于 engage_answer                                                */
    ///* 	test_time : 测试时间                                                                        */
    ///* 	use_time : use_time 属于 engage_answer                                                    */
    ///* 	total_point : 总分   
   public class Engage_answer
    {
        [Key]
        public int Ans_id { get; set; }
        public string Answer_number { get; set; }
        public string Exam_number { get; set; }
        public int Resume_id { get; set; }
        public int Interview_id { get; set; }
        public string Human_name { get; set; }
        public string Human_idcard { get; set; }
        public string Major_kind_id { get; set; }
        public string Major_kind_name { get; set; }
        public string Major_id { get; set; }
        public string Major_name { get; set; }
        public DateTime Test_time { get; set; }
        public string Use_time { get; set; }
        public double Total_point { get; set; }

    }
}
