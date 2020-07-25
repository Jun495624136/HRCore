using System;
using Model;
using IDAO;
using EFEntity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class UsersDAO3 : UsersIDAO3
    {
        private readonly HR_DBContext coreDbContext;
        public UsersDAO3(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }
        public async Task<int> Login(Users_Model u)
        {
            int a = 0;
            List<Users_Model> list = new List<Users_Model>();
            List<Users> list2 = await Task.Run(() => { return coreDbContext.User.ToList(); });
            foreach (Users item in list2)
            {
                if (u.U_name == item.U_name && u.U_password == item.U_password)
                {
                    a = 1;
                }
            }

            return a;
        }
        public int DL(Users_Model ff)
        {
            int a = 0;
            List<Users> list = coreDbContext.User.ToList();
            foreach (Users item in list)
            {
                if (ff.U_name == item.U_name && ff.U_password == item.U_password)
                {
                    a = 1;
                }
            }
            return a;
        }
        public DBFenYe<Users_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
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
            var list = coreDbContext.User.FromSqlRaw($@"exec proc_FenYe @pageSize,@keyName,@tabelName,@where,@currentPage,@rows out,@pages out", pt).ToList();
            DBFenYe<Users_Model> page = new DBFenYe<Users_Model>();
            page.li = new List<Users_Model>();
            foreach (var sr in list)
            {
                Users_Model ss = new Users_Model()
                {
                   JueSe_name= sr.JueSe_name,
                    U_id= sr.U_id,
                     U_name= sr.U_name,
                      U_password= sr.U_password,
                       U_true_name= sr.U_true_name
                };
                page.li.Add(ss);
            }
            page.Pages = (int)pt[5].Value;
            page.Rows = (int)pt[6].Value;
            return page;
        }
        public int sfcz(Users_Model bjm)
        {
            int a = 0;
            List<Users> list = coreDbContext.User.ToList();
            foreach (Users item in list)
            {
                if (bjm.U_name == item.U_name)
                {
                    a = 1;
                }
            }
            return a;
        }
        public async Task<int> Add(Users t)
        {
             coreDbContext.Set<Users>().Add(t);
            return  coreDbContext.SaveChanges();
        }
        public async Task<int> UserCreate(Users_Model bjm)
        {
            if (sfcz(bjm) == 1)
            {
                return 0;
            }
            else
            {
                Users us = new Users()
                {
                    U_id = bjm.U_id,
                    U_name = bjm.U_name,
                    U_true_name = bjm.U_true_name,
                    U_password = bjm.U_password,
                    JueSe_name = bjm.JueSe_name
                };
                return await Add(us);
            }  
        }

        public async Task<int> UserDelete(int id)
        {
            Users aa= await coreDbContext.User.FindAsync(id);
            coreDbContext.User.Remove(aa);
            return await coreDbContext.SaveChangesAsync();
        }

        public async Task<int> UserEdit(Users_Model bjm)
        {
            Users us = new Users()
            {
                U_id = bjm.U_id,
                U_name = bjm.U_name,
                U_password = bjm.U_password,
                U_true_name = bjm.U_true_name,
                JueSe_name = bjm.JueSe_name
            };
            coreDbContext.Attach(us);
            coreDbContext.Entry(us).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await coreDbContext.SaveChangesAsync();
        }

        public Users_Model UserSelectBy(int id)
        {
            //e.U_id == id)
            Users us2 = null;
            List <Users> us = coreDbContext.User.ToList();    //eo->dto
            foreach (Users item in us)
            {
                if (item.U_id == id) 
                {
                    us2 = item;
                };
            }
            Users_Model um = new Users_Model()
            {
                U_id = id,
                U_name = us2.U_name,
                U_true_name = us2.U_true_name,
                U_password = us2.U_password,
                JueSe_name = us2.JueSe_name
            };
            return um;
        }

        public string js(Users_Model u)
        {
            string a="";
            List<Users_Model> list = new List<Users_Model>();
            List<Users> list2 =  coreDbContext.User.ToList();
            foreach (Users item in list2)
            {
                if (u.U_name == item.U_name && u.U_password == item.U_password)
                {
                    a = item.JueSe_name;
                }
            }
            return a;
        }
    }
}
