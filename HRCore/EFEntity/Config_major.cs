using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
		///* 创建新表 config_major。                                                                       */
		///* config_major : 职位设置                                                                      */
		///* 	mak_id : 主键，自动增长列                                                                       */
		///* 	major_kind_id : 职位分类编号                                                                  */
		///* 	major_kind_name : 职位分类名称                                                                */
		///* 	major_id : 职位编号                                                                         */
		///* 	major_name : 职位名称                                                                       */
		///* 	test_amount : 题套数量                                                                      */
		//create table config_major(
		//	mak_id smallint identity not null,
		//	major_kind_id char(2) null,
		//major_kind_name varchar(60) null,
		//major_id char (2) null,
		//major_name varchar(60) null,
		//test_amount smallint null)  
   public class Config_major
    {
		[Key]
		public int Mak_id { get; set; }
		public string Major_kind_id { get; set; }
		public string Major_kind_name { get; set; }
		public string Major_id { get; set; }
		public string Major_name { get; set; }
		public int Test_amount { get; set; }
	}
}
