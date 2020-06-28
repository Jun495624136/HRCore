using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    public class YHquanxian
    {
        [Key]
        public int YHid { get; set; }//自增列
        public int JueSe_id { get; set; } //  用户id
        public int id { get; set; }    // 权限id
    }
}
