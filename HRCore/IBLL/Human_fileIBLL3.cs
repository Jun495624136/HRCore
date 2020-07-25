using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface Human_fileIBLL3
    {
        DBFenYe<Human_file_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize);
        Task<Human_file_Model> SelByID02(int id);
        Human_file_Model SelByID0(string id);
        Task<int> Up(Human_file_Model m);
    }
}
