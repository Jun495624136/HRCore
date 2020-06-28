using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //    /* 创建新表 engage_major_release。                                                               */
///* engage_major_release : 职位发表登记表                                                           */
///* 	mre_id : 主键，自动增长列                                                                       */
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
///* 	human_amount : 招聘人数                                                                     */
///* 	engage_type : 招聘类型                                                                      */
///* 	deadline : 截至日期                                                                         */
///* 	register : 登记人                                                                          */
///* 	changer : 变更人                                                                           */
///* 	regist_time : 登记时间                                                                      */
///* 	change_time : 变更时间                                                                      */
///* 	major_describe : 职位描述                                                                   */
///* 	engage_required : 招聘要求 
    public class Engage_major_release_Model
    {
        [Key]
        public int Mre_id { get; set; }
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
        public int Human_amount { get; set; }
        public string Engage_type { get; set; }
        public DateTime Deadline { get; set; }
        public string Register { get; set; }
        public string Changer { get; set; }
        public DateTime Regist_time { get; set; }
        public DateTime Change_time { get; set; }
        public string Major_describe { get; set; }
        public string Engage_required { get; set; }
    }
}
