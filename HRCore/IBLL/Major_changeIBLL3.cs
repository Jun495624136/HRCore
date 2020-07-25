using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
     public interface Major_changeIBLL3
    {
        Task<int> Ad(Major_change_Model m);
        DBFenYe<Major_change_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize);
        Task<Major_change_Model> SelByID02(int id);
        Task<int> Up(Major_change_Model m);
    }
}
