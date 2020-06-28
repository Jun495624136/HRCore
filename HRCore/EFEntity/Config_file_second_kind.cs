using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
	///* 创建新表 config_file_second_kind。                                                            */
	///* config_file_second_kind : 二级机构设置                                                         */
	///* 	fsk_id : 主键，自动增长列                                                                       */
	///* 	first_kind_id : 一级机构编号                                                                  */
	///* 	first_kind_name : 一级机构名称                                                                */
	///* 	second_kind_id : 二级机构编号                                                                 */
	///* 	second_kind_name : 二级机构名称                                                               */
	///* 	second_salary_id : 二级机构薪酬发放责任人编号                                                        */
	///* 	second_sale_id : 二级机构销售责任人编号                                                            */
	//create table config_file_second_kind(
	//	fsk_id smallint identity not null,
	//	first_kind_id char(2) ,
	//first_kind_name varchar(60) ,
	//second_kind_id char (2) ,
	//second_kind_name varchar(60) ,
	//second_salary_id text,
	//second_sale_id text )  
   public class Config_file_second_kind
    {
		[Key]
		public int Fsk_id { get; set; }
		public string First_kind_id { get; set; }
		public string First_kind_name { get; set; }
		public string Second_kind_id { get; set; }
		public string Second_kind_name { get; set; }

		public string Second_salary_id { get; set; }
		public string Second_sale_id { get; set; }
	}
}
