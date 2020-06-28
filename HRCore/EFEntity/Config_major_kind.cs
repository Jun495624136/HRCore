using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
     //   /* 创建新表 config_major_kind。                                                                  */
     //   /* config_major_kind : 职位分类设置                                                               */
     //   /* 	mfk_id : 主键，自动增长列                                                                       */
     //   /* 	major_kind_id : 职位分类编号                                                                  */
     //   /* 	major_kind_name : 职分类位名称                                                                */
     //   create table config_major_kind(
     //       mfk_id smallint identity not null,
     //       major_kind_id char(2) null,
	    //major_kind_name varchar(60) null)  

   public class Config_major_kind
    {
        [Key]
        public int Mfk_id { get; set; }
        public string Major_kind_id { get; set; }
        public string Major_kind_name { get; set; }
    }
}
