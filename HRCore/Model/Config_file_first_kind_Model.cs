using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //    /* 创建新表 config_file_first_kind。                                                             */
    ///* config_file_first_kind : 一级机构设置                                                          */
    ///* 	ffk_id : 主键，自动增长列                                                                       */
    ///* 	first_kind_id : 一级机构编号                                                                  */
    ///* 	first_kind_name : 一级机构名称                                                                */
    ///* 	first_kind_salary_id : 一级机构薪酬发放责任人编号                                                    */
    ///* 	first_kind_sale_id : 一级机构销售责任人编号           
   public class Config_file_first_kind_Model
    {
        [Key]
        public int Ffk_id { get; set; }
        public string First_kind_id { get; set; }
        public string First_kind_name { get; set; }
        public string First_kind_salary_id { get; set; }
        public string First_kind_sale_id { get; set; }
    }
}
