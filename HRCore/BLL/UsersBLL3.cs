using System;
using Model;
using IBLL;
using IDAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class UsersBLL3 : UsersIBLL3
    {
        private readonly UsersIDAO3 coreDbContext;
        public UsersBLL3(UsersIDAO3 coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }
        public int DL(Users_Model ff)
        {
            return coreDbContext.DL(ff);
        }

        public DBFenYe<Users_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
        {
            return coreDbContext.Fenye(dqy, tablename, where, keyname, pagesize);
        }

        public Task<int> Login(Users_Model u)
        {
            return coreDbContext.Login(u);
        }

        public int UserCreate(Users_Model bjm)
        {
            throw new NotImplementedException();
        }

        public Task<int> UserDelete(int id)
        {
            return coreDbContext.UserDelete(id);
        }

        public Users_Model UserSelectBy(int id)
        {
            return coreDbContext.UserSelectBy(id);
        }

        Task<int> UsersIBLL3.UserCreate(Users_Model bjm)
        {
            return coreDbContext.UserCreate(bjm);
        }

        public Task<int> UserEdit(Users_Model bjm)
        {
            return coreDbContext.UserEdit(bjm);
        }

        public string js(Users_Model um)
        {
            return coreDbContext.js(um);
        }
    }
}
