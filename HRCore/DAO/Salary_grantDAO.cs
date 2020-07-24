using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class Salary_grantDAO : ISalary_grantDAO
    {
        private readonly HR_DBContext dBContext;
        public Salary_grantDAO(HR_DBContext dBContext) 
        {
            this.dBContext = dBContext;
        }

        public List<Salary_grant_Model> FenYe(FenYeModel fenYe)
        {
            List<Salary_grant_Model> list = new List<Salary_grant_Model>();
            try
            {
                SqlParameter[] ps = {
                    new SqlParameter(){ParameterName="@pageSize",Value=fenYe.PageSize},
                       new SqlParameter(){ParameterName="@keyName",Value=fenYe.KeyName},
                       new SqlParameter(){ParameterName="@tableName",Value=fenYe.TableName},
                       new SqlParameter(){ParameterName="@where",Value=fenYe.Where},
                       new SqlParameter(){ParameterName="@currentPage",Value=fenYe.CurrentPage},
                       new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                       new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
                };
                var sql = dBContext.Salary_grants.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
                foreach (var item in sql)
                {
                    Salary_grant_Model sm = new Salary_grant_Model()
                    {
                        Sgr_id = item.Sgr_id,
                        Salary_grant_id = item.Salary_grant_id,
                        Salary_standard_id = item.Salary_standard_id,
                        First_kind_id=item.First_kind_id,
                        First_kind_name = item.First_kind_name,
                        Second_kind_id=item.Second_kind_id,
                        Second_kind_name = item.Second_kind_name,
                        Third_kind_id=item.Third_kind_id,
                        Third_kind_name = item.Third_kind_name,
                        Salary_standard_sum = item.Salary_standard_sum,
                        Salary_paid_sum = item.Salary_paid_sum
                    };
                    list.Add(sm);
                }
                fenYe.Pages = (int)ps[6].Value;
                fenYe.Rows = (int)ps[5].Value;
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_grantDAO", e);
            }
            return list;
        }

        public List<Human_file_Model> HumanFileSelect()
        {
            List<Human_file_Model> list = new List<Human_file_Model>();
            try
            {
                List<Human_file> result = dBContext.Human_files.ToList();
                foreach (var item in result)
                {
                    Human_file_Model human = new Human_file_Model()
                    {
                        Huf_id = item.Huf_id,
                        Human_id = item.Human_id,
                        First_kind_id = item.First_kind_id,
                        First_kind_name = item.First_kind_name,
                        Second_kind_id = item.Second_kind_id,
                        Second_kind_name = item.Second_kind_name,
                        Third_kind_id = item.Third_kind_id,
                        Third_kind_name = item.Third_kind_name,
                        Human_name = item.Human_name,
                        Human_address = item.Human_address,
                        Human_postcode = item.Human_postcode,
                        Human_pro_designation = item.Human_pro_designation,
                        Human_major_kind_id = item.Human_major_kind_id,
                        Human_major_kind_name = item.Human_major_kind_name,
                        Human_major_id = item.Human_major_id,
                        Hunma_major_name = item.Hunma_major_name,
                        Human_telephone = item.Human_telephone,
                        Human_mobilephone = item.Human_mobilephone,
                        Human_bank = item.Human_bank,
                        Human_account = item.Human_account,
                        Human_qq = item.Human_qq,
                        Human_email = item.Human_email,
                        Attachment_name = item.Attachment_name,
                        Bonus_amount = item.Bonus_amount,
                        Changer = item.Changer,
                        Change_time = item.Change_time,
                        Checker = item.Checker,
                        Check_status = item.Check_status,
                        Check_time = item.Check_time,
                        Delete_time = item.Delete_time,
                        File_chang_amount = item.File_chang_amount,
                        Human_age = item.Human_age,
                        Human_birthday = item.Human_birthday,
                        Human_birthplace = item.Human_birthplace,
                        Human_educated_degree = item.Human_educated_degree,
                        Human_educated_major = item.Human_educated_major,
                        Human_educated_years = item.Human_educated_years,
                        Human_family_membership = item.Human_family_membership,
                        Human_file_status = item.Human_file_status,
                        Human_histroy_records = item.Human_histroy_records,
                        Human_hobby = item.Human_hobby,
                        Human_id_card = item.Human_id_card,
                        Human_nationality = item.Human_nationality,
                        Human_party = item.Human_party,
                        Human_picture = item.Human_picture,
                        Human_race = item.Human_race,
                        Human_religion = item.Human_religion,
                        Human_sex = item.Human_sex,
                        Human_society_security_id = item.Human_society_security_id,
                        Human_speciality = item.Human_speciality,
                        Lastly_change_time = item.Lastly_change_time,
                        Major_change_amount = item.Major_change_amount,
                        Recovery_time = item.Recovery_time,
                        Register = item.Register,
                        Regist_time = item.Regist_time,
                        Remark = item.Remark,
                        Training_amount = item.Training_amount,
                        Salary_standard_id = item.Salary_standard_id,
                        Salary_standard_name = item.Salary_standard_name,
                        Salary_sum = item.Salary_sum,
                        Demand_salaray_sum = item.Demand_salaray_sum,
                        Paid_salary_sum = item.Paid_salary_sum,
                    };
                    list.Add(human);
                }
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_grantDAO", e);
            }
            return list;
        }

        public List<Salary_grant_Model> SalaryGrantSelect()
        {
            List<Salary_grant_Model> list = new List<Salary_grant_Model>();
            try
            {
                List<Salary_grant> salary_s = dBContext.Salary_grants.ToList();
                foreach (var item in salary_s)
                {
                    Salary_grant_Model salary_ = new Salary_grant_Model() 
                    {
                        Sgr_id=item.Sgr_id,
                        Salary_grant_id=item.Salary_grant_id,
                        Salary_standard_id=item.Salary_standard_id,
                        First_kind_id=item.First_kind_id,
                        First_kind_name=item.First_kind_name,
                        Second_kind_id=item.Second_kind_id,
                        Second_kind_name=item.Second_kind_name,
                        Third_kind_id=item.Third_kind_id,
                        Third_kind_name=item.Third_kind_name,
                        Human_amount=item.Human_amount,
                        Salary_paid_sum=item.Salary_paid_sum,
                        Salary_standard_sum=item.Salary_standard_sum,
                        Register=item.Register,
                        Regist_time=item.Regist_time,
                        Checker=item.Checker,
                        Check_status=item.Check_status,
                        Check_time=item.Check_time
                    };
                    list.Add(salary_);
                }
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_grantDAO", e);
            }
            return list;
        }

        public async Task<int> SalaryGrantUp(Salary_grant_Model salary)
        {
            try
            {
                Salary_grant salary1 = new Salary_grant()
                {
                    Salary_paid_sum = salary.Salary_paid_sum,
                    Salary_standard_sum = salary.Salary_standard_sum,
                    Sgr_id = salary.Sgr_id
                };
                dBContext.Salary_grants.Attach(salary1);
                dBContext.Entry(salary1).Property(e => e.Salary_paid_sum).IsModified = true;
                dBContext.Entry(salary1).Property(e => e.Salary_standard_sum).IsModified = true;
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_grantDAO", e);
            }

            return await dBContext.SaveChangesAsync();
        }

        public async Task<int> SalaryGrantUpdate(Salary_grant_Model salary)
        {
            try
            {
                Salary_grant salary1 = new Salary_grant()
                {
                    Salary_paid_sum = salary.Salary_paid_sum,
                    Salary_standard_sum = salary.Salary_standard_sum,
                    Checker=salary.Checker,
                    Check_status=salary.Check_status,
                    Check_time=salary.Check_time,
                    Sgr_id = salary.Sgr_id
                };
                dBContext.Salary_grants.Attach(salary1);
                dBContext.Entry(salary1).Property(e => e.Salary_paid_sum).IsModified = true;
                dBContext.Entry(salary1).Property(e => e.Salary_standard_sum).IsModified = true;
                dBContext.Entry(salary1).Property(e => e.Checker).IsModified = true;
                dBContext.Entry(salary1).Property(e => e.Check_status).IsModified = true;
                dBContext.Entry(salary1).Property(e => e.Check_time).IsModified = true;
            }
            catch (Exception e)
            {
                ExceptionM.WriteLog("Salary_grantDAO", e);
            }
            return await dBContext.SaveChangesAsync();
        }
    }
}
