using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFEntity;
using IDAO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAO
{
   public class Engage_resumeDAO:IEngage_resumeDAO
    {
        private readonly HR_DBContext hR_DBContext;
        public Engage_resumeDAO(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }

        public Task<int> Add(Engage_resume_Model cfk)
        {
            Engage_resume emr = new Engage_resume()
            {
                Res_id = cfk.Res_id,
                Human_name = cfk.Human_name,
                Engage_type = cfk.Engage_type,
                Human_address = cfk.Human_address,
                Human_postcode = cfk.Human_postcode,
                Human_major_kind_id = cfk.Human_major_kind_id,

                Human_major_kind_name = cfk.Human_major_kind_name,
                Human_major_id = cfk.Human_major_id,
                Human_major_name = cfk.Human_major_name,
                Human_telephone = cfk.Human_telephone,
                Human_homephone = cfk.Human_homephone,
                Human_mobilephone = cfk.Human_mobilephone,
                Human_email = cfk.Human_email,
                Human_hobby = cfk.Human_hobby,
                Human_specility = cfk.Human_specility,
                Human_sex = cfk.Human_sex,
                Human_religion = cfk.Human_religion,
                Human_party = cfk.Human_party,
                Human_nationality = cfk.Human_nationality,
                Human_race = cfk.Human_race,
                Human_birthday = cfk.Human_birthday,
                Human_age = cfk.Human_age,
                Human_educated_degree = cfk.Human_educated_degree,
                Human_educated_years = cfk.Human_educated_years,
                Human_educated_major = cfk.Human_educated_major,
                Human_college = cfk.Human_college,
                Human_idcard = cfk.Human_idcard,
                Human_birthplace = cfk.Human_birthplace,
                Demand_salary_standard = cfk.Demand_salary_standard,
                Human_history_records = cfk.Human_history_records,
                Remark = cfk.Remark,
                Recomandation = cfk.Recomandation,
                Human_picture = cfk.Human_picture,
                Attachment_name = cfk.Attachment_name,
                Check_status = cfk.Check_status,
                Register = cfk.Register,
                Regist_time = cfk.Regist_time,
                Checker = cfk.Checker,
                Check_time = cfk.Check_time,
                Interview_status = cfk.Interview_status,
                Total_points = cfk.Total_points,
                Test_amount = cfk.Test_amount,
                Test_checker = cfk.Test_checker,
                Test_check_time = cfk.Test_check_time,
                Pass_register = cfk.Pass_register,
                Pass_regist_time = cfk.Pass_regist_time,
                Pass_checker = cfk.Pass_checker,
                Pass_check_time = cfk.Check_time,
                Pass_check_status = cfk.Pass_check_status,
                Pass_checkComment = cfk.Pass_checkComment,
                Pass_passComment = cfk.Pass_passComment
            };
            hR_DBContext.Engage_resumes.Add(emr);
            return hR_DBContext.SaveChangesAsync();
        }

        public Engage_resume_Model CfSelectBy(int id)
        {
            Engage_resume cfk = hR_DBContext.Engage_resumes.Find(id);
            Engage_resume_Model sss = new Engage_resume_Model()
            {
                Res_id = cfk.Res_id,
                Human_name = cfk.Human_name,
                Engage_type = cfk.Engage_type,
                Human_address = cfk.Human_address,
                Human_postcode = cfk.Human_postcode,
                Human_major_kind_id = cfk.Human_major_kind_id,

                Human_major_kind_name = cfk.Human_major_kind_name,
                Human_major_id = cfk.Human_major_id,
                Human_major_name = cfk.Human_major_name,
                Human_telephone = cfk.Human_telephone,
                Human_homephone = cfk.Human_homephone,
                Human_mobilephone = cfk.Human_mobilephone,
                Human_email = cfk.Human_email,
                Human_hobby = cfk.Human_hobby,
                Human_specility = cfk.Human_specility,
                Human_sex = cfk.Human_sex,
                Human_religion = cfk.Human_religion,
                Human_party = cfk.Human_party,
                Human_nationality = cfk.Human_nationality,
                Human_race = cfk.Human_race,
                Human_birthday = cfk.Human_birthday,
                Human_age = cfk.Human_age,
                Human_educated_degree = cfk.Human_educated_degree,
                Human_educated_years = cfk.Human_educated_years,
                Human_educated_major = cfk.Human_educated_major,
                Human_college = cfk.Human_college,
                Human_idcard = cfk.Human_idcard,
                Human_birthplace = cfk.Human_birthplace,
                Demand_salary_standard = cfk.Demand_salary_standard,
                Human_history_records = cfk.Human_history_records,
                Remark = cfk.Remark,
                Recomandation = cfk.Recomandation,
                Human_picture = cfk.Human_picture,
                Attachment_name = cfk.Attachment_name,
                Check_status = cfk.Check_status,
                Register = cfk.Register,
                Regist_time = cfk.Regist_time,
                Checker = cfk.Checker,
                Check_time = cfk.Check_time,
                Interview_status = cfk.Interview_status,
                Total_points = cfk.Total_points,
                Test_amount = cfk.Test_amount,
                Test_checker = cfk.Test_checker,
                Test_check_time = cfk.Test_check_time,
                Pass_register = cfk.Pass_register,
                Pass_regist_time = cfk.Pass_regist_time,
                Pass_checker = cfk.Pass_checker,
                Pass_check_time = cfk.Check_time,
                Pass_check_status = cfk.Pass_check_status,
                Pass_checkComment = cfk.Pass_checkComment,
                Pass_passComment = cfk.Pass_passComment
            };
            return sss;
        }

        public List<Engage_resume_Model> FenYe(FenYeModel fen)
        {
            List<Engage_resume_Model> list = new List<Engage_resume_Model>();

            SqlParameter[] ps = {
                    new SqlParameter(){ParameterName="@pageSize",Value=fen.PageSize},
                       new SqlParameter(){ParameterName="@keyName",Value=fen.KeyName},
                       new SqlParameter(){ParameterName="@tableName",Value=fen.TableName},
                       new SqlParameter(){ParameterName="@where",Value=fen.Where},
                       new SqlParameter(){ParameterName="@currentPage",Value=fen.CurrentPage},
                       new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                       new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
                };
            var sql = hR_DBContext.Engage_resumes.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
            foreach (var ad in sql)
            {
                Engage_resume_Model sm = new Engage_resume_Model()
                {
                   Res_id=ad.Res_id,
                   Human_name=ad.Human_name,
                   Human_sex=ad.Human_sex,
                   Human_age=ad.Human_age,
                   Human_college=ad.Human_college,
                   Human_educated_major=ad.Human_educated_major,
                   Human_major_name=ad.Human_major_name,
                   Human_major_kind_name=ad.Human_major_kind_name,
                   Human_telephone=ad.Human_telephone,
                   Check_status=ad.Check_status,
                   Interview_status=ad.Interview_status
                   
                };
                list.Add(sm);
            }
            fen.Pages = (int)ps[6].Value;
            fen.Rows = (int)ps[5].Value;

            return list;
        }

        public async Task<int> ResumeUpdate(Engage_resume_Model erm)
        {
            Engage_resume er = new Engage_resume()
            {

                Checker = erm.Checker,
                Check_time = erm.Check_time,
                Recomandation = erm.Recomandation,
                Res_id =erm.Res_id,
                Check_status = erm.Check_status
            };
            hR_DBContext.Engage_resumes.Attach(er);
            hR_DBContext.Entry(er).Property(e => e.Checker).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Check_time).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Recomandation).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Check_status).IsModified = true;
            return await hR_DBContext.SaveChangesAsync();
        }

        public async Task<int> ResumeUpdate2(Engage_resume_Model erm)
        {
            Engage_resume er = new Engage_resume()
            {

               
                Res_id = erm.Res_id,
                Interview_status=erm.Interview_status
               
            };
            hR_DBContext.Engage_resumes.Attach(er);
            hR_DBContext.Entry(er).Property(e => e.Interview_status).IsModified = true;
            return await hR_DBContext.SaveChangesAsync();
        }

        public List<Engage_resume_Model> ResumeUpSelect()
        {
            var cfk1 = hR_DBContext.Engage_resumes.ToList();
            List<Engage_resume_Model> list = new List<Engage_resume_Model>();
            foreach (var cfk in cfk1)
            {
                Engage_resume_Model emr = new Engage_resume_Model()
                {
                    Res_id = cfk.Res_id,
                    Human_name = cfk.Human_name,
                    Engage_type = cfk.Engage_type,
                    Human_address = cfk.Human_address,
                    Human_postcode = cfk.Human_postcode,
                    Human_major_kind_id = cfk.Human_major_kind_id,

                    Human_major_kind_name = cfk.Human_major_kind_name,
                    Human_major_id = cfk.Human_major_id,
                    Human_major_name = cfk.Human_major_name,
                    Human_telephone = cfk.Human_telephone,
                    Human_homephone = cfk.Human_homephone,
                    Human_mobilephone = cfk.Human_mobilephone,
                    Human_email = cfk.Human_email,
                    Human_hobby = cfk.Human_hobby,
                    Human_specility = cfk.Human_specility,
                    Human_sex = cfk.Human_sex,
                    Human_religion = cfk.Human_religion,
                    Human_party = cfk.Human_party,
                    Human_nationality = cfk.Human_nationality,
                    Human_race = cfk.Human_race,
                    Human_birthday = cfk.Human_birthday,
                    Human_age = cfk.Human_age,
                    Human_educated_degree = cfk.Human_educated_degree,
                    Human_educated_years = cfk.Human_educated_years,
                    Human_educated_major = cfk.Human_educated_major,
                    Human_college = cfk.Human_college,
                    Human_idcard = cfk.Human_idcard,
                    Human_birthplace = cfk.Human_birthplace,
                    Demand_salary_standard = cfk.Demand_salary_standard,
                    Human_history_records = cfk.Human_history_records,
                    Remark = cfk.Remark,
                    Recomandation = cfk.Recomandation,
                    Human_picture = cfk.Human_picture,
                    Attachment_name = cfk.Attachment_name,
                    Check_status = cfk.Check_status,
                    Register = cfk.Register,
                    Regist_time = cfk.Regist_time,
                    Checker = cfk.Checker,
                    Check_time = cfk.Check_time,
                    Interview_status = cfk.Interview_status,
                    Total_points = cfk.Total_points,
                    Test_amount = cfk.Test_amount,
                    Test_checker = cfk.Test_checker,
                    Test_check_time = cfk.Test_check_time,
                    Pass_register = cfk.Pass_register,
                    Pass_regist_time = cfk.Pass_regist_time,
                    Pass_checker = cfk.Pass_checker,
                    Pass_check_time = cfk.Check_time,
                    Pass_check_status = cfk.Pass_check_status,
                    Pass_checkComment = cfk.Pass_checkComment,
                    Pass_passComment = cfk.Pass_passComment
                };
                list.Add(emr);
            }
            return list;
        }

        public async Task<Engage_resume_Model> SelectResume(int id)
        {
            Engage_resume cfk = await hR_DBContext.Engage_resumes.FindAsync(id);
            Engage_resume_Model cffkm = new Engage_resume_Model()
            {
                Res_id = cfk.Res_id,
                Human_name = cfk.Human_name,
                Engage_type = cfk.Engage_type,
                Human_address = cfk.Human_address,
                Human_postcode = cfk.Human_postcode,
                Human_major_kind_id = cfk.Human_major_kind_id,
                Human_major_kind_name = cfk.Human_major_kind_name,
                Human_major_id = cfk.Human_major_id,
                Human_major_name = cfk.Human_major_name,
                Human_telephone = cfk.Human_telephone,
                Human_homephone = cfk.Human_homephone,
                Human_mobilephone = cfk.Human_mobilephone,
                Human_email = cfk.Human_email,
                Human_hobby = cfk.Human_hobby,
                Human_specility = cfk.Human_specility,
                Human_sex = cfk.Human_sex,
                Human_religion = cfk.Human_religion,
                Human_party = cfk.Human_party,
                Human_nationality = cfk.Human_nationality,
                Human_race = cfk.Human_race,
                Human_birthday = cfk.Human_birthday,
                Human_age = cfk.Human_age,
                Human_educated_degree = cfk.Human_educated_degree,
                Human_educated_years = cfk.Human_educated_years,
                Human_educated_major = cfk.Human_educated_major,
                Human_college = cfk.Human_college,
                Human_idcard = cfk.Human_idcard,
                Human_birthplace = cfk.Human_birthplace,
                Demand_salary_standard = cfk.Demand_salary_standard,
                Human_history_records = cfk.Human_history_records,
                Remark = cfk.Remark,
                Recomandation = cfk.Recomandation,
                Human_picture = cfk.Human_picture,
                Attachment_name = cfk.Attachment_name,
                Check_status = cfk.Check_status,
                Register = cfk.Register,
                Regist_time = cfk.Regist_time,
                Checker = cfk.Checker,
                Check_time = cfk.Check_time,
                Interview_status = cfk.Interview_status,
                Total_points = cfk.Total_points,
                Test_amount = cfk.Test_amount,
                Test_checker = cfk.Test_checker,
                Test_check_time = cfk.Test_check_time,
                Pass_register = cfk.Pass_register,
                Pass_regist_time = cfk.Pass_regist_time,
                Pass_checker = cfk.Pass_checker,
                Pass_check_time = cfk.Check_time,
                Pass_check_status = cfk.Pass_check_status,
                Pass_checkComment = cfk.Pass_checkComment,
                Pass_passComment = cfk.Pass_passComment

            };
            return cffkm;
        }

    }
}
