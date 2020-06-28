using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //    /* 创建新表 bonus。                                                                              */
    ///* bonus : 激励登记表                                                                            */
    ///* 	bon_id : 主键，自动增长列                                                                       */
    ///* 	major_kind_id : 职位分类编号                                                                  */
    ///* 	major_kind_name : 职位分类名称                                                                */
    ///* 	major_id : 职位编号                                                                         */
    ///* 	major_name : 职位名称                                                                       */
    ///* 	human_id : 人力资源档案编号                                                                     */
    ///* 	human_name : 姓名                                                                         */
    ///* 	bonus_item : 激励项目名称                                                                     */
    ///* 	bonus_worth : 激励价值                                                                      */
    ///* 	bonus_degree : 激励等级                                                                     */
    ///* 	remark : 备注                                                                             */
    ///* 	register : 登记人                                                                          */
    ///* 	checker : 复核人                                                                           */
    ///* 	regist_time : 登记时间                                                                      */
    ///* 	check_time : 复核时间                                                                       */
    ///* 	check_status : 复核状态 
   public class Bonus_Model
    {
        [Key]
        public int Bon_id { get; set; }
        public string Major_kind_id { get; set; }
        public string Major_kind_name { get; set; }
        public string Major_id { get; set; }
        public string Major_name { get; set; }
        public string Human_id { get; set; }
        public string Human_name { get; set; }
        public string Bonus_item { get; set; }
        public double Bonus_worth { get; set; }
        public string Bonus_degree { get; set; }
        public string Remark { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public DateTime Regist_time { get; set; }
        public DateTime Check_time { get; set; }
        public int Check_status { get; set; }
    }
}
