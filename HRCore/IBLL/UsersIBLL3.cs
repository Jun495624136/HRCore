using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
    public interface UsersIBLL3
    {
        int DL(Users_Model ff);
        DBFenYe<Users_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize);
        Task<int> UserCreate(Users_Model bjm);
        Task<int> UserDelete(int id);
        Users_Model UserSelectBy(int id);
        Task<int> UserEdit(Users_Model bjm);
        Task<int> Login(Users_Model u);
        string js(Users_Model um);
    }
}
