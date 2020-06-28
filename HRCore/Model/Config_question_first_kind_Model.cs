using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
 //   /* 创建新表 config_question_first_kind。                                                         */
 //   /* config_question_first_kind : 试题一级分类设置                                                    */
 //   /* 	qfk_id : 主键，自动增长列                                                                       */
 //   /* 	first_kind_id : 试题一级分类编号                                                                */
 //   /* 	first_kind_name : 试题一级分类名称                                                              */
 //   create table config_question_first_kind(
 //       qfk_id smallint identity not null,
 //       first_kind_id char(2) ,
	//first_kind_name varchar(60) )  
   public class Config_question_first_kind_Model
    {
        [Key]
        public int Qfk_id { get; set; }
        public string First_kind_id { get; set; }
        public string First_kind_name { get; set; }
    }
}
