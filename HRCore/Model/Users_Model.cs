using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Users_Model
    {
        ///* user : 用户表                                                                               */
        ///* 	user_id : 主键，自动增长列                                                                      */
        ///* 	user_name : 用户名                                                                         */
        ///* 	user_true_name : 真实姓名                                                                   */
        //* 	user_password : 密码  
        [Key]
        public int U_id { get; set; }//user_id : 主键，自动增长列   
        [Required(ErrorMessage = "用户名不能为空")]
        //[Range(0, 100, ErrorMessage = "年龄范围是0-100之间")]
        //[RegularExpression(@"\d+")]
        public string U_name { get; set; }//	user_name : 用户名    
        public string U_true_name { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(8, MinimumLength = 5, ErrorMessage = "密码长度为5到8位数")]
        public string U_password { get; set; }
        public string JueSe_name { get; set; }//用户身份
    }
}
