using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public  class JueSeDAO : JueSeIDAO
    {
        private readonly HR_DBContext coreDbContext;
        public JueSeDAO(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public async Task<int> ADD(JueSeModel bjm)
        {
            JueSe a = new JueSe() { JueSe_name=bjm.JueSe_name, SFky=bjm.SFky };
            coreDbContext.JueSes.Add(a);
            return await coreDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            JueSe aa = await coreDbContext.JueSes.FindAsync(id);
            coreDbContext.JueSes.Remove(aa);
            return await coreDbContext.SaveChangesAsync();
        }

        public DBFenYe<JueSeModel> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
        {
            SqlParameter[] pt =
             {
                new SqlParameter(){ParameterName="@pageSize",Value=pagesize},
                new SqlParameter(){ParameterName="@keyName",Value=keyname},
                new SqlParameter(){ParameterName="@tabelName",Value=tablename},
                new SqlParameter(){ParameterName="@where",Value=where},
                new SqlParameter(){ParameterName="@currentPage",Value=dqy},
                new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
            };
            var list = coreDbContext.JueSes.FromSqlRaw($@"exec proc_FenYe @pageSize,@keyName,@tabelName,@where,@currentPage,@rows out,@pages out", pt).ToList();
            DBFenYe<JueSeModel> page = new DBFenYe<JueSeModel>();
            page.li = new List<JueSeModel>();
            foreach (var sr in list)
            {
                JueSeModel ss = new JueSeModel()
                {
                    JueSe_id=sr.JueSe_id,
                     JueSe_name=sr.JueSe_name,
                      SFky=sr.SFky
                };
                page.li.Add(ss);
            }
            page.Pages = (int)pt[5].Value;
            page.Rows = (int)pt[6].Value;
            return page;
        }

        public async Task<List<JueSeModel>> RoleSelect()
        {
            List<JueSeModel> list = new List<JueSeModel>();
            List<JueSe> list1 = await Task.Run(()=> { return coreDbContext.JueSes.ToList(); });
            foreach (JueSe item in list1)
            {
                JueSeModel um = new JueSeModel()
                {
                    JueSe_id = item.JueSe_id,
                    JueSe_name = item.JueSe_name
                };
                list.Add(um);
            }
            return  list;
        }

        public async Task<JueSeModel> select(int id)
        {
            JueSe a =await coreDbContext.JueSes.FindAsync(id);
            JueSeModel b = new JueSeModel()
            {
                JueSe_id = a.JueSe_id,
                JueSe_name = a.JueSe_name,
                SFky = a.SFky 
            };
            return b;
        }
    }
}
