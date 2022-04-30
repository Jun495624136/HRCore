using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //    /* 创建新表 engage_interview。                                                                   */
    ///* engage_interview : 面试表                                                                   */
    ///* 	ein_id : 主键，自动增长列                                                                       */
    ///* 	human_name : 姓名                                                                         */
    ///* 	interview_amount : 面试次数                                                                 */
    ///* 	human_major_kind_id : 职位分类编号                                                            */
    ///* 	human_major_kind_name : 职位分类名称                                                          */
    ///* 	human_major_id : 职位编号                                                                   */
    ///* 	human_major_name : 职位名称                                                                 */
    ///* 	image_degree : 形象等级                                                                     */
    ///* 	native_language_degree : 口才等级                                                           */
    ///* 	foreign_language_degree : 外语水平等级                                                        */
    ///* 	response_speed_degree : 应变能力                                                            */
    ///* 	EQ_degree : EQ等级                                                                        */
    ///* 	IQ_degree : IQ_等级                                                                       */
    ///* 	multi_quality_degree : 综合素质                                                             */
    ///* 	register : 面试人                                                                          */
    ///* 	checker : 筛选人                                                                           */
    ///* 	registe_time : 面试时间                                                                     */
    ///* 	check_time : 筛选时间                                                                       */
    ///* 	resume_id : 简历编号                                                                        */
    ///* 	result : 面试结果                                                                           */
    ///* 	interview_comment : 面试评价                                                                */
    ///* 	check_comment : 筛选评价                                                                    */
    ///* 	interview_status : 面试状态                                                                 */
    ///* 	check_status : 筛选状态 
   public class Engage_interview_Model
    {
        [Key]
        public int Ein_id { get; set; }
        public string Human_name { get; set; }
        public int Interview_amount { get; set; }
        public string Human_major_kind_id { get; set; }
        public string Human_major_kind_name { get; set; }
        public string Human_major_id { get; set; }
        public string Human_major_name { get; set; }
        public string Image_degree { get; set; }
        public string Native_language_degree { get; set; }
        public string Foreign_language_degree { get; set; }
        public string Response_speed_degree { get; set; }
        public string EQ_degree { get; set; }
        public string IQ_degree { get; set; }
        public string Multi_quality_degree { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public DateTime Registe_time { get; set; }
        public DateTime Check_time { get; set; }
        public int Resume_id { get; set; }
        public string Result { get; set; }
        public string Interview_comment { get; set; }
        public string Check_comment { get; set; }
        public int Interview_status { get; set; }
        public int Check_status { get; set; }
        //public Engage_resume_Model engage_Resume_Model { get; set; }
    }
}
