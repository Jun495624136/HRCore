using System;
using System.Collections.Generic;
using System.Text;
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
    public class Human_fileDAO : IHuman_fileDAO
    {
        private readonly HR_DBContext hR_DBContext;
        public Human_fileDAO(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }
        public Task<int> Add(Human_file_Model hfm)
        {
            Human_file sss = new Human_file
            {
                Huf_id = hfm.Huf_id,
                Attachment_name = hfm.Attachment_name,
                Bonus_amount = hfm.Bonus_amount,
                Changer = hfm.Changer,
                Change_time = hfm.Change_time,
                Checker = hfm.Checker,
                Check_status = hfm.Check_status,
                Check_time = hfm.Check_time,
                Delete_time = hfm.Delete_time,
                Demand_salaray_sum = hfm.Demand_salaray_sum,
                File_chang_amount = hfm.File_chang_amount,
                First_kind_id = hfm.First_kind_id,
                First_kind_name = hfm.First_kind_name,
                Human_account = hfm.Human_account,
                Human_address = hfm.Human_address,
                Human_age = hfm.Human_age,
                Human_bank = hfm.Human_bank,
                Human_birthday = hfm.Human_birthday,
                Human_birthplace = hfm.Human_birthplace,
                Human_educated_degree = hfm.Human_educated_degree,
                Human_educated_major = hfm.Human_educated_major,
                Human_educated_years = hfm.Human_educated_years,
                Human_email = hfm.Human_email,
                Human_family_membership = hfm.Human_family_membership,
                Human_file_status = hfm.Human_file_status,
                Human_histroy_records = hfm.Human_histroy_records,
                Human_hobby = hfm.Human_hobby,
                Human_id = hfm.Human_id,
                Human_id_card = hfm.Human_id_card,
                Human_major_id = hfm.Human_major_id,
                Human_major_kind_id = hfm.Human_major_kind_id,
                Human_major_kind_name = hfm.Human_major_kind_name,
                Human_mobilephone = hfm.Human_mobilephone,
                Human_name = hfm.Human_name,
                Human_nationality = hfm.Human_nationality,
                Human_party = hfm.Human_party,
                Human_picture = hfm.Human_picture,
                Human_postcode = hfm.Human_postcode,
                Human_pro_designation = hfm.Human_pro_designation,
                Human_qq = hfm.Human_qq,
                Human_race = hfm.Human_race,
                Human_religion = hfm.Human_religion,
                Human_sex = hfm.Human_sex,
                Human_society_security_id = hfm.Human_society_security_id,
                Human_speciality = hfm.Human_speciality,
                Human_telephone = hfm.Human_telephone,
                Hunma_major_name = hfm.Hunma_major_name,
                Lastly_change_time = hfm.Lastly_change_time,
                Major_change_amount = hfm.Major_change_amount,
                Paid_salary_sum = hfm.Paid_salary_sum,
                Recovery_time = hfm.Recovery_time,
                Register = hfm.Register,
                Regist_time = hfm.Regist_time,
                Remark = hfm.Remark,
                Salary_standard_id = hfm.Salary_standard_id,
                Salary_standard_name = hfm.Salary_standard_name,
                Salary_sum = hfm.Salary_sum - hfm.Salary_sum,
                Second_kind_id = hfm.Second_kind_id,
                Second_kind_name = hfm.Second_kind_name,
                Third_kind_id = hfm.Third_kind_id,
                Third_kind_name = hfm.Third_kind_name,
                Training_amount = hfm.Training_amount
            };
            hR_DBContext.Human_files.Add(sss);
            return hR_DBContext.SaveChangesAsync();
        }

        public async Task<int> deleteid(int id)
        {
            Human_file file =await hR_DBContext.Human_files.FindAsync(id);
            hR_DBContext.Human_files.Remove(file);
            return await hR_DBContext.SaveChangesAsync();
        }

        public List<Human_file_Model> FenYe(FenYeModel fen)
        {
            List<Human_file_Model> list = new List<Human_file_Model>();

            SqlParameter[] ps = {
                    new SqlParameter(){ParameterName="@pageSize",Value=fen.PageSize},
                       new SqlParameter(){ParameterName="@keyName",Value=fen.KeyName},
                       new SqlParameter(){ParameterName="@tableName",Value=fen.TableName},
                       new SqlParameter(){ParameterName="@where",Value=fen.Where},
                       new SqlParameter(){ParameterName="@currentPage",Value=fen.CurrentPage},
                       new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                       new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
                };
            var sql = hR_DBContext.Human_files.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
            foreach (var ad in sql)
            {
                Human_file_Model sm = new Human_file_Model()
                {
                    Huf_id=ad.Huf_id,
                 Human_id=ad.Human_id,
                 Human_name=ad.Human_name,
                 Human_sex=ad.Human_sex,
                 First_kind_name=ad.First_kind_name,
                 Second_kind_name=ad.Second_kind_name,
                 Third_kind_name=ad.Third_kind_name,
                 Human_pro_designation=ad.Human_pro_designation,
                 Human_major_kind_name=ad.Human_major_kind_name,
                 Hunma_major_name=ad.Hunma_major_name,
                };
                list.Add(sm);
            }
            fen.Pages = (int)ps[6].Value;
            fen.Rows = (int)ps[5].Value;

            return list;
        }

        public async Task<int> FileUpdate(Human_file_Model erm)
        {
            Human_file er = new Human_file()
            {
                Huf_id=erm.Huf_id,
                Human_sex=erm.Human_sex,
                Human_pro_designation=erm.Human_pro_designation,
                Human_nationality=erm.Human_nationality,
                Human_race=erm.Human_race,
                Human_religion=erm.Human_religion,
                Human_party=erm.Human_party,
                Human_educated_degree=erm.Human_educated_degree,
                Human_educated_years=erm.Human_educated_years,
                Human_educated_major=erm.Human_educated_major,
                Human_speciality=erm.Human_speciality,
                Human_hobby=erm.Human_hobby,
                Changer=erm.Changer,
                Change_time=erm.Change_time,
                Salary_standard_name = erm.Salary_standard_name
            };
            hR_DBContext.Human_files.Attach(er);
            hR_DBContext.Entry(er).Property(e => e.Human_sex).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_pro_designation).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_nationality).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_race).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_religion).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_party).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_educated_degree).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_educated_years).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_educated_major).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_speciality).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_hobby).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Changer).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Change_time).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Salary_standard_name).IsModified = true;
            return await hR_DBContext.SaveChangesAsync();
        }

        public async Task<Human_file_Model> SelectById(int id)
        {
            Human_file hfm = await hR_DBContext.Human_files.FindAsync(id);
            Human_file_Model cffkm = new Human_file_Model()
            {
                Huf_id = hfm.Huf_id,
                Attachment_name = hfm.Attachment_name,
                Bonus_amount = hfm.Bonus_amount,
                Changer = hfm.Changer,
                Change_time = hfm.Change_time,
                Checker = hfm.Checker,
                Check_status = hfm.Check_status,
                Check_time = hfm.Check_time,
                Delete_time = hfm.Delete_time,
                Demand_salaray_sum = hfm.Demand_salaray_sum,
                File_chang_amount = hfm.File_chang_amount,
                First_kind_id = hfm.First_kind_id,
                First_kind_name = hfm.First_kind_name,
                Human_account = hfm.Human_account,
                Human_address = hfm.Human_address,
                Human_age = hfm.Human_age,
                Human_bank = hfm.Human_bank,
                Human_birthday = hfm.Human_birthday,
                Human_birthplace = hfm.Human_birthplace,
                Human_educated_degree = hfm.Human_educated_degree,
                Human_educated_major = hfm.Human_educated_major,
                Human_educated_years = hfm.Human_educated_years,
                Human_email = hfm.Human_email,
                Human_family_membership = hfm.Human_family_membership,
                Human_file_status = hfm.Human_file_status,
                Human_histroy_records = hfm.Human_histroy_records,
                Human_hobby = hfm.Human_hobby,
                Human_id = hfm.Human_id,
                Human_id_card = hfm.Human_id_card,
                Human_major_id = hfm.Human_major_id,
                Human_major_kind_id = hfm.Human_major_kind_id,
                Human_major_kind_name = hfm.Human_major_kind_name,
                Human_mobilephone = hfm.Human_mobilephone,
                Human_name = hfm.Human_name,
                Human_nationality = hfm.Human_nationality,
                Human_party = hfm.Human_party,
                Human_picture = hfm.Human_picture,
                Human_postcode = hfm.Human_postcode,
                Human_pro_designation = hfm.Human_pro_designation,
                Human_qq = hfm.Human_qq,
                Human_race = hfm.Human_race,
                Human_religion = hfm.Human_religion,
                Human_sex = hfm.Human_sex,
                Human_society_security_id = hfm.Human_society_security_id,
                Human_speciality = hfm.Human_speciality,
                Human_telephone = hfm.Human_telephone,
                Hunma_major_name = hfm.Hunma_major_name,
                Lastly_change_time = hfm.Lastly_change_time,
                Major_change_amount = hfm.Major_change_amount,
                Paid_salary_sum = hfm.Paid_salary_sum,
                Recovery_time = hfm.Recovery_time,
                Register = hfm.Register,
                Regist_time = hfm.Regist_time,
                Remark = hfm.Remark,
                Salary_standard_id = hfm.Salary_standard_id,
                Salary_standard_name = hfm.Salary_standard_name,
                Salary_sum = hfm.Salary_sum - hfm.Salary_sum,
                Second_kind_id = hfm.Second_kind_id,
                Second_kind_name = hfm.Second_kind_name,
                Third_kind_id = hfm.Third_kind_id,
                Third_kind_name = hfm.Third_kind_name,
                Training_amount = hfm.Training_amount
            };
            return cffkm;
        }

        public async Task<int> Update(Human_file_Model hfm)
        {
            Human_file er = new Human_file()
            {
                Huf_id = hfm.Huf_id,
                Human_sex = hfm.Human_sex,
                Human_pro_designation = hfm.Human_pro_designation,
                Human_nationality = hfm.Human_nationality,
                Human_race = hfm.Human_race,
                Human_religion = hfm.Human_religion,
                Human_party = hfm.Human_party,
                Human_educated_degree = hfm.Human_educated_degree,
                Human_educated_years = hfm.Human_educated_years,
                Human_educated_major = hfm.Human_educated_major,
                Human_speciality = hfm.Human_speciality,
                Human_hobby = hfm.Human_hobby,
                Check_status=hfm.Check_status,
                Check_time=hfm.Check_time,
                Checker=hfm.Checker,
                Salary_standard_name=hfm.Salary_standard_name,

            };
            hR_DBContext.Human_files.Attach(er);
            hR_DBContext.Entry(er).Property(e => e.Human_sex).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_pro_designation).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_nationality).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_race).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_religion).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_party).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_educated_degree).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_educated_years).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_educated_major).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_speciality).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Salary_standard_name).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Human_hobby).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Check_status).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Change_time).IsModified = true;
            hR_DBContext.Entry(er).Property(e => e.Checker).IsModified = true;
            return await hR_DBContext.SaveChangesAsync();
        }

        public List<Human_file_Model> SelectQuery() 
        {
            var hfm1 = hR_DBContext.Human_files.ToList();
            List<Human_file_Model> list = new List<Human_file_Model>();
            foreach (var hfm in hfm1)
            {
                Human_file_Model cffkm = new Human_file_Model()
                {
                    Huf_id = hfm.Huf_id,
                    Attachment_name = hfm.Attachment_name,
                    Bonus_amount = hfm.Bonus_amount,
                    Changer = hfm.Changer,
                    Change_time = hfm.Change_time,
                    Checker = hfm.Checker,
                    Check_status = hfm.Check_status,
                    Check_time = hfm.Check_time,
                    Delete_time = hfm.Delete_time,
                    Demand_salaray_sum = hfm.Demand_salaray_sum,
                    File_chang_amount = hfm.File_chang_amount,
                    First_kind_id = hfm.First_kind_id,
                    First_kind_name = hfm.First_kind_name,
                    Human_account = hfm.Human_account,
                    Human_address = hfm.Human_address,
                    Human_age = hfm.Human_age,
                    Human_bank = hfm.Human_bank,
                    Human_birthday = hfm.Human_birthday,
                    Human_birthplace = hfm.Human_birthplace,
                    Human_educated_degree = hfm.Human_educated_degree,
                    Human_educated_major = hfm.Human_educated_major,
                    Human_educated_years = hfm.Human_educated_years,
                    Human_email = hfm.Human_email,
                    Human_family_membership = hfm.Human_family_membership,
                    Human_file_status = hfm.Human_file_status,
                    Human_histroy_records = hfm.Human_histroy_records,
                    Human_hobby = hfm.Human_hobby,
                    Human_id = hfm.Human_id,
                    Human_id_card = hfm.Human_id_card,
                    Human_major_id = hfm.Human_major_id,
                    Human_major_kind_id = hfm.Human_major_kind_id,
                    Human_major_kind_name = hfm.Human_major_kind_name,
                    Human_mobilephone = hfm.Human_mobilephone,
                    Human_name = hfm.Human_name,
                    Human_nationality = hfm.Human_nationality,
                    Human_party = hfm.Human_party,
                    Human_picture = hfm.Human_picture,
                    Human_postcode = hfm.Human_postcode,
                    Human_pro_designation = hfm.Human_pro_designation,
                    Human_qq = hfm.Human_qq,
                    Human_race = hfm.Human_race,
                    Human_religion = hfm.Human_religion,
                    Human_sex = hfm.Human_sex,
                    Human_society_security_id = hfm.Human_society_security_id,
                    Human_speciality = hfm.Human_speciality,
                    Human_telephone = hfm.Human_telephone,
                    Hunma_major_name = hfm.Hunma_major_name,
                    Lastly_change_time = hfm.Lastly_change_time,
                    Major_change_amount = hfm.Major_change_amount,
                    Paid_salary_sum = hfm.Paid_salary_sum,
                    Recovery_time = hfm.Recovery_time,
                    Register = hfm.Register,
                    Regist_time = hfm.Regist_time,
                    Remark = hfm.Remark,
                    Salary_standard_id = hfm.Salary_standard_id,
                    Salary_standard_name = hfm.Salary_standard_name,
                    Salary_sum = hfm.Salary_sum - hfm.Salary_sum,
                    Second_kind_id = hfm.Second_kind_id,
                    Second_kind_name = hfm.Second_kind_name,
                    Third_kind_id = hfm.Third_kind_id,
                    Third_kind_name = hfm.Third_kind_name,
                    Training_amount = hfm.Training_amount
                };
                list.Add(cffkm);
            }
          
            return list;
        }

        public async Task<int> Updatestatus(Human_file_Model erm)
        {
            Human_file hm = new Human_file()
            {
                Huf_id=erm.Huf_id,
                Human_file_status=erm.Human_file_status,
            };
            hR_DBContext.Human_files.Attach(hm);
            hR_DBContext.Entry(hm).Property(e => e.Human_file_status).IsModified = true;
            return await hR_DBContext.SaveChangesAsync();
        }

        public async Task<int> Updatepictr(Human_file_Model erm)
        {
            Human_file hm = new Human_file()
            {
                Huf_id = erm.Huf_id,
                Human_picture=erm.Human_picture
            };
            hR_DBContext.Human_files.Attach(hm);
            hR_DBContext.Entry(hm).Property(e => e.Human_picture).IsModified = true;
            return await hR_DBContext.SaveChangesAsync();
        }


        public List<Human_file_Model> SelectQuery2()
        {
            var hfm1 = hR_DBContext.Human_files.ToList();
            List<Human_file_Model> list = new List<Human_file_Model>();
            foreach (var hfm in hfm1)
            {
                Human_file_Model cffkm = new Human_file_Model()
                {
                    Huf_id = hfm.Huf_id,
                    Attachment_name = hfm.Attachment_name,
                    Bonus_amount = hfm.Bonus_amount,
                    Changer = hfm.Changer,
                    Change_time = hfm.Change_time,
                    Checker = hfm.Checker,
                    Check_status = hfm.Check_status,
                    Check_time = hfm.Check_time,
                    Delete_time = hfm.Delete_time,
                    Demand_salaray_sum = hfm.Demand_salaray_sum,
                    File_chang_amount = hfm.File_chang_amount,
                    First_kind_id = hfm.First_kind_id,
                    First_kind_name = hfm.First_kind_name,
                    Human_account = hfm.Human_account,
                    Human_address = hfm.Human_address,
                    Human_age = hfm.Human_age,
                    Human_bank = hfm.Human_bank,
                    Human_birthday = hfm.Human_birthday,
                    Human_birthplace = hfm.Human_birthplace,
                    Human_educated_degree = hfm.Human_educated_degree,
                    Human_educated_major = hfm.Human_educated_major,
                    Human_educated_years = hfm.Human_educated_years,
                    Human_email = hfm.Human_email,
                    Human_family_membership = hfm.Human_family_membership,
                    Human_file_status = hfm.Human_file_status,
                    Human_histroy_records = hfm.Human_histroy_records,
                    Human_hobby = hfm.Human_hobby,
                    Human_id = hfm.Human_id,
                    Human_id_card = hfm.Human_id_card,
                    Human_major_id = hfm.Human_major_id,
                    Human_major_kind_id = hfm.Human_major_kind_id,
                    Human_major_kind_name = hfm.Human_major_kind_name,
                    Human_mobilephone = hfm.Human_mobilephone,
                    Human_name = hfm.Human_name,
                    Human_nationality = hfm.Human_nationality,
                    Human_party = hfm.Human_party,
                    Human_picture = hfm.Human_picture,
                    Human_postcode = hfm.Human_postcode,
                    Human_pro_designation = hfm.Human_pro_designation,
                    Human_qq = hfm.Human_qq,
                    Human_race = hfm.Human_race,
                    Human_religion = hfm.Human_religion,
                    Human_sex = hfm.Human_sex,
                    Human_society_security_id = hfm.Human_society_security_id,
                    Human_speciality = hfm.Human_speciality,
                    Human_telephone = hfm.Human_telephone,
                    Hunma_major_name = hfm.Hunma_major_name,
                    Lastly_change_time = hfm.Lastly_change_time,
                    Major_change_amount = hfm.Major_change_amount,
                    Paid_salary_sum = hfm.Paid_salary_sum,
                    Recovery_time = hfm.Recovery_time,
                    Register = hfm.Register,
                    Regist_time = hfm.Regist_time,
                    Remark = hfm.Remark,
                    Salary_standard_id = hfm.Salary_standard_id,
                    Salary_standard_name = hfm.Salary_standard_name,
                    Salary_sum = hfm.Salary_sum - hfm.Salary_sum,
                    Second_kind_id = hfm.Second_kind_id,
                    Second_kind_name = hfm.Second_kind_name,
                    Third_kind_id = hfm.Third_kind_id,
                    Third_kind_name = hfm.Third_kind_name,
                    Training_amount = hfm.Training_amount
                };
                list.Add(cffkm);
            }
           
            return list;
        }
    }
}
