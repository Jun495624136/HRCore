using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace IDAO
{
    public interface Human_fileIDAO3
    {

        DBFenYe<Human_file_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize);
        Task<Human_file_Model> SelByID02(int id);
        Human_file_Model SelByID0(string id);
        //int HREdit(Human_file_Model h);
        Task<int> Up(Human_file_Model m);
    }
}
