using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
    public  interface Major_changeIDAO
    {
        Task<int> Ad(Major_change_Model m);
        DBFenYe<Major_change_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize);
        Task<Major_change_Model> SelByID02(int id);
        Major_change_Model SelById(int id);
        Task<int> Up(Major_change_Model m);
        List<Major_change_Model> Sel();
    }
}
