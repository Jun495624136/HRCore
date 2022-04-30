using System;
using System.Collections.Generic;
using System.Text;
using Model;
using EFEntity;
using IDAO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace DAO
{
    public class Major_changeDAO3 : Major_changeIDAO
    {
        private readonly HR_DBContext coreDbContext;
        public Major_changeDAO3(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public async Task<int> Ad(Major_change_Model m)
        {
            Major_change mm = new Major_change()
            {
                Mch_id = m.Mch_id,
                First_kind_id = m.First_kind_id,
                First_kind_name = m.First_kind_name,
                Second_kind_id = m.Second_kind_id,
                Second_kind_name = m.Second_kind_name,
                Third_kind_id = m.Third_kind_id,
                Third_kind_name = m.Third_kind_name,
                Major_id = m.Major_id,
                Major_name = m.Major_name,
                Major_kind_id = m.Major_kind_id,
                Major_kind_name = m.Major_kind_name,
                New_first_kind_id = m.New_first_kind_id,
                New_first_kind_name = m.New_first_kind_name,
                New_second_kind_id = m.New_second_kind_id,
                New_second_kind_name = m.New_second_kind_name,
                New_third_kind_id = m.New_third_kind_id,
                New_third_kind_name = m.New_third_kind_name,
                New_major_id = m.New_major_id,
                New_major_name = m.New_major_name,
                New_major_kind_id = m.New_major_kind_id,
                New_major_kind_name = m.New_major_kind_name,
                Human_id = m.Human_id,
                Human_name = m.Human_name,
                Salary_standard_id = m.Salary_standard_id,
                Salary_standard_name = m.Salary_standard_name,
                Salary_sum = m.Salary_sum,
                New_salary_standard_id = m.New_salary_standard_id,
                New_salary_standard_name = m.New_salary_standard_name,
                New_salary_sum = m.New_salary_sum,
                Change_reason = m.Change_reason,
                Check_reason = m.Check_reason,
                Check_status = m.Check_status,
                Register = m.Register,
                Checker = m.Checker,
                Regist_time = m.Regist_time,
                Check_time = m.Regist_time
            };
            coreDbContext.Major_changes.Add(mm);
            return await coreDbContext.SaveChangesAsync();
        }

        public DBFenYe<Major_change_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
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
            var list = coreDbContext.Major_changes.FromSqlRaw($@"exec proc_FenYe @pageSize,@keyName,@tabelName,@where,@currentPage,@rows out,@pages out", pt).ToList();
            DBFenYe<Major_change_Model> page = new DBFenYe<Major_change_Model>();
            page.li = new List<Major_change_Model>();
            foreach (var sr in list)
            {
                Major_change_Model ss = new Major_change_Model()
                {
                    Change_reason = sr.Change_reason,
                    Check_reason = sr.Check_reason,
                    Checker = sr.Checker,
                    Check_status = sr.Check_status,
                    Check_time = sr.Check_time,
                    First_kind_id = sr.First_kind_id,
                    First_kind_name = sr.First_kind_name,
                    Human_id = sr.Human_id,
                    Human_name = sr.Human_name,
                    Major_id = sr.Major_id,
                    Major_kind_id = sr.Major_kind_id,
                    Major_kind_name = sr.Major_kind_name,
                    Major_name = sr.Major_name,
                    Mch_id = sr.Mch_id,
                    New_first_kind_id = sr.New_first_kind_id,
                    New_first_kind_name = sr.New_first_kind_name,
                    New_major_id = sr.New_major_id,
                    New_major_kind_id = sr.New_major_kind_id,
                    New_major_kind_name = sr.New_major_kind_name,
                    New_major_name = sr.New_major_name,
                    New_salary_standard_id = sr.New_salary_standard_id,
                    New_salary_standard_name = sr.New_salary_standard_name,
                    New_salary_sum = sr.New_salary_sum,
                    New_second_kind_id = sr.New_second_kind_id,
                    New_second_kind_name = sr.New_second_kind_name,
                    New_third_kind_id = sr.New_third_kind_id,
                    New_third_kind_name = sr.New_third_kind_name,
                    Register = sr.Register,
                    Regist_time = sr.Regist_time,
                    Salary_standard_id = sr.Salary_standard_id,
                    Salary_standard_name = sr.Salary_standard_name,
                    Salary_sum = sr.Salary_sum,
                    Second_kind_id = sr.Second_kind_id,
                    Second_kind_name = sr.Second_kind_name,
                    Third_kind_id = sr.Third_kind_id,
                    Third_kind_name = sr.Third_kind_name
                };
                page.li.Add(ss);
            }
            page.Pages = (int)pt[5].Value;
            page.Rows = (int)pt[6].Value;
            return page;
        }

        public Dictionary<int, List<Major_change_Model>> FenYeMajor_change(int currepage, int pagesize)
        {

            throw new NotImplementedException();
        }

        public List<Major_change_Model> Sel()
        {
            throw new NotImplementedException();
        }

        public Major_change_Model SelById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Major_change_Model> SelByID02(int id)
        {
            Major_change m = await coreDbContext.Major_changes.FindAsync(id);
            Major_change_Model mm = new Major_change_Model()
            {
                Mch_id = m.Mch_id,
                First_kind_id = m.First_kind_id,
                First_kind_name = m.First_kind_name,
                Second_kind_id = m.Second_kind_id,
                Second_kind_name = m.Second_kind_name,
                Third_kind_id = m.Third_kind_id,
                Third_kind_name = m.Third_kind_name,
                Major_id = m.Major_id,
                Major_name = m.Major_name,
                Major_kind_id = m.Major_kind_id,
                Major_kind_name = m.Major_kind_name,
                New_first_kind_id = m.New_first_kind_id,
                New_first_kind_name = m.New_first_kind_name,
                New_second_kind_id = m.New_second_kind_id,
                New_second_kind_name = m.New_second_kind_name,
                New_third_kind_id = m.New_third_kind_id,
                New_third_kind_name = m.New_third_kind_name,
                New_major_id = m.New_major_id,
                New_major_name = m.New_major_name,
                New_major_kind_id = m.New_major_kind_id,
                New_major_kind_name = m.New_major_kind_name,
                Human_id = m.Human_id,
                Human_name = m.Human_name,
                Salary_standard_id = m.Salary_standard_id,
                Salary_standard_name = m.Salary_standard_name,
                Salary_sum = m.Salary_sum,
                New_salary_standard_id = m.New_salary_standard_id,
                New_salary_standard_name = m.New_salary_standard_name,
                New_salary_sum = m.New_salary_sum,
                Change_reason = m.Change_reason,
                Check_reason = m.Check_reason,
                Check_status = m.Check_status,
                Register = m.Register,
                Checker = m.Checker,
                Regist_time = m.Regist_time,
                Check_time = m.Regist_time
            };
            return mm;
        }

        public async Task<int> Up(Major_change_Model m)
        {
            Major_change mc = new Major_change()
            {
                Mch_id = m.Mch_id,
                First_kind_id = m.First_kind_id,
                First_kind_name = m.First_kind_name,
                Second_kind_id = m.Second_kind_id,
                Second_kind_name = m.Second_kind_name,
                Third_kind_id = m.Third_kind_id,
                Third_kind_name = m.Third_kind_name,
                Major_id = m.Major_id,
                Major_name = m.Major_name,
                Major_kind_id = m.Major_kind_id,
                Major_kind_name = m.Major_kind_name,
                New_first_kind_id = m.New_first_kind_id,
                New_first_kind_name = m.New_first_kind_name,
                New_second_kind_id = m.New_second_kind_id,
                New_second_kind_name = m.New_second_kind_name,
                New_third_kind_id = m.New_third_kind_id,
                New_third_kind_name = m.New_third_kind_name,
                New_major_id = m.New_major_id,
                New_major_name = m.New_major_name,
                New_major_kind_id = m.New_major_kind_id,
                New_major_kind_name = m.New_major_kind_name,
                Human_id = m.Human_id,
                Human_name = m.Human_name,
                Salary_standard_id = m.Salary_standard_id,
                Salary_standard_name = m.Salary_standard_name,
                Salary_sum = Convert.ToDouble(m.Salary_sum),
                New_salary_standard_id = m.New_salary_standard_id,
                New_salary_standard_name = m.New_salary_standard_name,
                New_salary_sum = m.New_salary_sum,
                Change_reason = m.Change_reason,
                Check_reason = m.Check_reason,
                Check_status = m.Check_status,
                Register = m.Register,
                Checker = m.Checker,
                Regist_time = m.Regist_time,
                Check_time = m.Check_time
            };
            Major_change aa =await coreDbContext.Major_changes.FindAsync(mc.Mch_id);
            coreDbContext.Major_changes.Remove(aa);
            coreDbContext.Major_changes.Add(mc);
            return await coreDbContext.SaveChangesAsync();
        }
    }
}
