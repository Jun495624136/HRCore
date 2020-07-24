using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public static class ExceptionM
    {
        public static void WriteLog(string fileName, Exception ex)
        {

            using (StreamWriter sw = new StreamWriter("D:\\错误日志.txt", true))
            {
                sw.WriteLine("错误信息：" + ex.Message);
                sw.WriteLine("错误时间：" + DateTime.Now.ToString());
                sw.WriteLine("错误文件:" + fileName);
            }
        }
    }
}
