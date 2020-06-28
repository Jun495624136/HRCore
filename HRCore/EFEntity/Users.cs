using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
   public class Users
    {
        ///* user : 用户表                                                                               */
        ///* 	user_id : 主键，自动增长列                                                                      */
        ///* 	user_name : 用户名                                                                         */
        ///* 	user_true_name : 真实姓名                                                                   */
        //* 	user_password : 密码  
        [Key]
        public int U_id { get; set; }//user_id : 主键，自动增长列   
        public string U_name { get; set; }//	user_name : 用户名    
        public string U_true_name { get; set; }
        public string U_password { get; set; }
        public string JueSe_name { get; set; }//用户身份
    }
}
