using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class FenYeModel
    {
        public int Pages { get; set; }
        public int Rows { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string Where { get; set; }
        public string TableName { get; set; }
        public string KeyName { get; set; }
    }
}
