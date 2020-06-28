using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    //    /* 创建新表 engage_subjects。                                                                    */
    ///* engage_subjects : 试题题库登记表                                                                */
    ///* 	sub_id : 主键，自动增长列                                                                       */
    ///* 	first_kind_id : 试题I级分类编号                                                                */
    ///* 	first_kind_name : 试题I级分类名称                                                              */
    ///* 	second_kind_id : 试题II级分类编号                                                              */
    ///* 	second_kind_name : 试题II级分类名称                                                            */
    ///* 	register : 登记人                                                                          */
    ///* 	regist_time : 登记时间                                                                      */
    ///* 	derivation : 试题出处                                                                       */
    ///* 	content : 题干                                                                            */
    ///* 	key_a : 答案a                                                                             */
    ///* 	key_b : 答案b                                                                             */
    ///* 	key_c : 答案c                                                                             */
    ///* 	key_d : 答案d                                                                             */
    ///* 	key_e : 答案e                                                                             */
    ///* 	correct_key : 正确答案                                                                      */
    ///* 	changer : 变更人                                                                           */
    ///* 	change_time : 变更时间 
   public class Engage_subjects
    {
        [Key]
        public int Sub_id { get; set; }
        public string First_kind_id { get; set; }
        public string First_kind_name { get; set; }
        public string Second_kind_id { get; set; }
        public string Second_kind_name { get; set; }
        public string Register { get; set; }
        public DateTime Regist_time { get; set; }
        public string Derivation { get; set; }
        public string Content { get; set; }
        public string Key_a { get; set; }
        public string Key_b { get; set; }
        public string Key_c { get; set; }

        public string Key_d { get; set; }
        public string Key_e { get; set; }
        public string Correct_key { get; set; }
        public string Changer { get; set; }
        public DateTime Change_time { get; set; }
    }
}
