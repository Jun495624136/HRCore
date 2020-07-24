using System;
using System.Collections.Generic;
using Model;
using IDAO;
using EFEntity;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAO
{
    public class Salary_standard_DAO : ISalary_standard_DAO
    {
        public readonly HR_DBContext dBContext;
        public Salary_standard_DAO(HR_DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public List<Salary_standard_Model> FenYe(FenYeModel fen)
        {
            List<Salary_standard_Model> list = new List<Salary_standard_Model>();
            try
            {
                SqlParameter[] ps = {
                    new SqlParameter(){ParameterName="@pageSize",Value=fen.PageSize},
                       new SqlParameter(){ParameterName="@keyName",Value=fen.KeyName},
                       new SqlParameter(){ParameterName="@tableName",Value=fen.TableName},
                       new SqlParameter(){ParameterName="@where",Value=fen.Where},
                       new SqlParameter(){ParameterName="@currentPage",Value=fen.CurrentPage},
                       new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                       new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
                };
                var sql = dBContext.Salary_standards.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
                foreach (var item in sql)
                {
                    Salary_standard_Model sm = new Salary_standard_Model()
                    {
                        Ssd_id = item.Ssd_id,
                        Standard_id = item.Standard_id,
                        Standard_name = item.Standard_name,
                        Designer = item.Designer,
                        Regist_time = item.Regist_time,
                        Salary_sum = item.Salary_sum
                    };
                    list.Add(sm);
                }
                fen.Pages = (int)ps[6].Value;
                fen.Rows = (int)ps[5].Value;
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_standard_DAO", e);
            }
            return list;
        }

        public async Task<int> Salary_standard_Add(Salary_standard_Model salary_)
        {
            try
            {
                Salary_standard salary_1 = new Salary_standard()
                {
                    Standard_id = salary_.Standard_id,
                    Standard_name = salary_.Standard_name,
                    Designer = salary_.Designer,
                    Register = salary_.Register,
                    Regist_time = salary_.Regist_time,
                    Salary_sum = salary_.Salary_sum,
                    Remark = salary_.Remark
                };
                dBContext.Salary_standards.Add(salary_1);
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_standard_DAO", e);
            }
            return await dBContext.SaveChangesAsync();
        }

        public async Task<int> Salary_standard_CheckerUpdate(Salary_standard_Model salary_)
        {
            try
            {
                Salary_standard salary_1 = new Salary_standard()
                {
                    Ssd_id = salary_.Ssd_id,
                    Standard_name = salary_.Standard_name,
                    Designer = salary_.Designer,
                    Checker = salary_.Checker,
                    Check_time = salary_.Check_time,
                    Salary_sum = salary_.Salary_sum,
                    Check_status = salary_.Check_status,
                    Check_comment = salary_.Check_comment
                };
                dBContext.Salary_standards.Attach(salary_1);
                dBContext.Entry(salary_1).Property(e => e.Standard_name).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Checker).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Salary_sum).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Designer).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Check_comment).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Check_status).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Check_time).IsModified = true;
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_standard_DAO", e);
            }
            return await dBContext.SaveChangesAsync();
        }

        public List<Salary_standard_Model> Salary_standard_Select()
        {
            List<Salary_standard> salary_s = dBContext.Salary_standards.ToList();
            List<Salary_standard_Model> salary_Standard_s = new List<Salary_standard_Model>();
            try
            {
                foreach (Salary_standard item in salary_s)
                {
                    Salary_standard_Model salary_ = new Salary_standard_Model()
                    {
                        Ssd_id = item.Ssd_id,
                        Standard_name = item.Standard_name,
                        Standard_id = item.Standard_id,
                        Designer = item.Designer,
                        Register = item.Register,
                        Regist_time = item.Regist_time,
                        Remark = item.Remark,
                        Changer = item.Changer,
                        Change_time = item.Change_time,
                        Change_status = item.Change_status,
                        Checker = item.Checker,
                        Salary_sum = item.Salary_sum,
                        Check_time = item.Check_time,
                        Check_comment = item.Check_comment,
                        Check_status = item.Check_status
                    };
                    salary_Standard_s.Add(salary_);
                }
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_standard_DAO", e);
            }
            return salary_Standard_s;
        }

        public async Task<int> Salary_standard_Update(Salary_standard_Model salary_)
        {
            try
            {
                Salary_standard salary_1 = new Salary_standard()
                {
                    Ssd_id = salary_.Ssd_id,
                    Standard_name = salary_.Standard_name,
                    Designer = salary_.Designer,
                    Checker = salary_.Checker,
                    Check_time = salary_.Check_time,
                    Salary_sum = salary_.Salary_sum,
                    Check_status = salary_.Check_status,
                    Check_comment = salary_.Check_comment,
                    Changer = salary_.Changer,
                    Change_time = salary_.Change_time,
                    Change_status = salary_.Change_status
                };
                dBContext.Salary_standards.Attach(salary_1);
                dBContext.Entry(salary_1).Property(e => e.Standard_name).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Checker).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Salary_sum).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Designer).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Check_comment).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Check_status).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Check_time).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Changer).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Change_time).IsModified = true;
                dBContext.Entry(salary_1).Property(e => e.Change_status).IsModified = true;
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_standard_DAO", e);
            }
            return await dBContext.SaveChangesAsync();
        }
    }
}
