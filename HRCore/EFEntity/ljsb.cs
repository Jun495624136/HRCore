using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFEntity
{
    public class ljsb
    {
        [Key]
        public int id { get; set; }//id  主键
        public string text { get; set; } // 可访问页面
        public string URL { get; set; } //  页面路径
        public string state { get; set; } //父子级
        public int JUid { get; set; } //  父级为0   子机值为父级ID
        public int @checked { get; set; }
    }
}
