using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class FenYeModel
    {
        public int Pages { get; set; }//总页数
        public int Rows { get; set; }//记录数
        public int CurrentPage { get; set; }//当前页
        public int PageSize { get; set; }//显示多少条数据
        public string Where { get; set; }//条件
        public string TableName { get; set; }//表名
        public string KeyName { get; set; }//主键
    }
}
