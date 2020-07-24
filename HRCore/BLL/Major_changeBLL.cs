using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IBLL;
using IDAO;
using System.Threading.Tasks;

namespace BLL
{
    public class Major_changeBLL:Major_changeIBLL
    {
        private readonly Major_changeIDAO coreDbContext;
        public Major_changeBLL(Major_changeIDAO coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public Task<int> Ad(Major_change_Model m)
        {
            return coreDbContext.Ad(m);
        }

        public DBFenYe<Major_change_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
        {
            return coreDbContext.Fenye(dqy,tablename,where,keyname,pagesize);
        }

        public Task<Major_change_Model> SelByID02(int id)
        {
            return coreDbContext.SelByID02(id);
        }

        public Task<int> Up(Major_change_Model m)
        {
            return coreDbContext.Up(m);
        }
    }
}
