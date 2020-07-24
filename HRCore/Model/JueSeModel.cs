using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JueSeModel
    {
        [Key]
        public int JueSe_id { get; set; }//user_id : 主键，自动增长列   
        public string JueSe_name { get; set; }//	user_name : 用户身份    
        public int SFky { get; set; }//是否可用

    }
}
