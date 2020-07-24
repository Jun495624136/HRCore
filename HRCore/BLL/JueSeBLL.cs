using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using IBLL;
using System.Threading.Tasks;

namespace BLL
{
    public  class JueSeBLL : JueSeIBLL
    {
        private readonly JueSeIDAO coreDbContext;
        public JueSeBLL(JueSeIDAO coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public Task<int> ADD(JueSeModel bjm)
        {
            return coreDbContext.ADD(bjm);
        }

        public Task<int> Delete(int id)
        {
            return coreDbContext.Delete(id);
        }

        public DBFenYe<JueSeModel> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
        {
            return coreDbContext.Fenye(dqy,tablename,where,keyname,pagesize);
        }

        public async Task<List<JueSeModel>> RoleSelect()
        {
            return await coreDbContext.RoleSelect();
        }

        public async Task<JueSeModel> select(int id)
        {
            return await coreDbContext.select(id);
        }
    }
}
