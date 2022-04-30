using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using IBLL;
using System.Threading.Tasks;

namespace BLL
{
    public class Human_fileBLL3 : Human_fileIBLL3
    {
        private readonly Human_fileIDAO3 coreDbContext;
        public Human_fileBLL3(Human_fileIDAO3 coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }
        public DBFenYe<Human_file_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
        {
            return coreDbContext.Fenye(dqy,tablename,where,keyname,pagesize);
        }

        public Human_file_Model SelByID0(string id)
        {
            return coreDbContext.SelByID0(id);
        }

        public Task<Human_file_Model> SelByID02(int id)
        {
            return coreDbContext.SelByID02(id);
        }

        public Task<int> Up(Human_file_Model m)
        {
            return coreDbContext.Up(m);
        }
    }
}
