using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using EFEntity;
using Model;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAO
{
    public class Human_fileDAO : Human_fileIDAO
    {
        private readonly HR_DBContext coreDbContext;
        public Human_fileDAO(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }
        public DBFenYe<Human_file_Model> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
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
            var list = coreDbContext.Human_files.FromSqlRaw($@"exec proc_FenYe @pageSize,@keyName,@tabelName,@where,@currentPage,@rows out,@pages out", pt).ToList();
            DBFenYe<Human_file_Model> page = new DBFenYe<Human_file_Model>();
            page.li = new List<Human_file_Model>();
            foreach (var item in list)
            {
                Human_file_Model ss = new Human_file_Model()
                {
                    Huf_id = item.Huf_id,
                    Attachment_name = item.Attachment_name,
                    Bonus_amount = item.Bonus_amount,
                    Changer = item.Changer,
                    Change_time = item.Change_time,
                    Checker = item.Checker,
                    Check_status = item.Check_status,
                    Check_time = item.Check_time,
                    Delete_time = item.Delete_time,
                    Demand_salaray_sum = item.Demand_salaray_sum,
                    File_chang_amount = item.File_chang_amount,
                    First_kind_id = item.First_kind_id,
                    First_kind_name = item.First_kind_name,
                    Human_account = item.Human_account,
                    Human_address = item.Human_address,
                    Human_age = item.Human_age,
                    Human_bank = item.Human_bank,
                    Human_birthday = item.Human_birthday,
                    Human_birthplace = item.Human_birthplace,
                    Human_educated_degree = item.Human_educated_degree,
                    Human_educated_major = item.Human_educated_major,
                    Human_educated_years = item.Human_educated_years,
                    Human_email = item.Human_email,
                    Human_family_membership = item.Human_family_membership,
                    Human_file_status = item.Human_file_status,
                    Human_histroy_records = item.Human_histroy_records,
                    Human_hobby = item.Human_hobby,
                    Human_id = item.Human_id,
                    Human_id_card = item.Human_id_card,
                    Human_major_id = item.Human_major_id,
                    Human_major_kind_id = item.Human_major_kind_id,
                    Human_major_kind_name = item.Human_major_kind_name,
                    Human_mobilephone = item.Human_mobilephone,
                    Human_name = item.Human_name,
                    Human_nationality = item.Human_nationality,
                    Human_party = item.Human_party,
                    Human_picture = item.Human_picture,
                    Human_postcode = item.Human_postcode,
                    Human_pro_designation = item.Human_pro_designation,
                    Human_qq = item.Human_qq,
                    Human_race = item.Human_race,
                    Human_religion = item.Human_religion,
                    Human_sex = item.Human_sex,
                    Human_society_security_id = item.Human_society_security_id,
                    Human_speciality = item.Human_speciality,
                    Human_telephone = item.Human_telephone,
                    Hunma_major_name = item.Hunma_major_name,
                    Lastly_change_time = item.Lastly_change_time,
                    Major_change_amount = item.Major_change_amount,
                    Paid_salary_sum = item.Paid_salary_sum,
                    Recovery_time = item.Recovery_time,
                    Register = item.Register,
                    Regist_time = item.Regist_time,
                    Remark = item.Remark,
                    Salary_standard_id = item.Salary_standard_id,
                    Salary_standard_name = item.Salary_standard_name,
                    Salary_sum = item.Salary_sum,
                    Second_kind_id = item.Second_kind_id,
                    Second_kind_name = item.Second_kind_name,
                    Third_kind_id = item.Third_kind_id,
                    Third_kind_name = item.Third_kind_name,
                    Training_amount = item.Training_amount,
                };
                page.li.Add(ss);
            }
            page.Pages = (int)pt[5].Value;
            page.Rows = (int)pt[6].Value;
            return page;
        }


        //public int HREdit(Human_file_Model h)
        //{
        //    Human_file hf = new Human_file
        //    {
        //        Huf_id = h.Huf_id,
        //        Human_id = h.Human_id,
        //        First_kind_id = h.First_kind_id,
        //        First_kind_name = h.First_kind_name,
        //        Second_kind_id = h.Second_kind_id,
        //        Second_kind_name = h.Second_kind_name,
        //        Third_kind_id = h.Third_kind_id,
        //        Third_kind_name = h.Third_kind_name,
        //        Human_name = h.Human_name,
        //        Human_address = h.Human_address,
        //        Human_postcode = h.Human_postcode,
        //        Human_pro_designation = h.Human_pro_designation,
        //        Human_major_kind_id = h.Human_major_kind_id,
        //        Human_major_kind_name = h.Human_major_kind_name,
        //        Human_major_id = h.Human_major_id,
        //        Hunma_major_name = h.Hunma_major_name,
        //        Human_telephone = h.Human_telephone,
        //        Human_mobilephone = h.Human_mobilephone,
        //        Human_bank = h.Human_bank,
        //        Human_account = h.Human_account,
        //        Human_qq = h.Human_qq,
        //        Human_email = h.Human_email,
        //        Human_hobby = h.Human_hobby,
        //        Human_speciality = h.Human_speciality,
        //        Human_sex = h.Human_sex,
        //        Human_religion = h.Human_religion,
        //        Human_party = h.Human_party,
        //        Human_nationality = h.Human_nationality,
        //        Human_race = h.Human_race,
        //        Human_birthday = h.Human_birthday,
        //        Human_birthplace = h.Human_birthplace,
        //        Human_age = h.Human_age,
        //        Human_educated_degree = h.Human_educated_degree,
        //        Human_educated_years = h.Human_educated_years,
        //        Human_educated_major = h.Human_educated_major,
        //        Human_society_security_id = h.Human_society_security_id,
        //        Human_id_card = h.Human_id_card,
        //        Remark = h.Remark,
        //        Salary_standard_id = h.Salary_standard_id,
        //        Salary_standard_name = h.Salary_standard_name,
        //        Salary_sum = h.Salary_sum,
        //        Demand_salaray_sum = h.Demand_salaray_sum,
        //        Paid_salary_sum = h.Paid_salary_sum,
        //        Major_change_amount = h.Major_change_amount,
        //        Bonus_amount = h.Bonus_amount,
        //        Training_amount = h.Training_amount,
        //        File_chang_amount = h.File_chang_amount,
        //        Human_histroy_records = h.Human_histroy_records,
        //        Human_family_membership = h.Human_family_membership,
        //        Human_picture = h.Human_picture,
        //        Attachment_name = h.Attachment_name,
        //        Check_status = h.Check_status,
        //        Register = h.Register,
        //        Checker = h.Checker,
        //        Changer = h.Changer,
        //        Regist_time = h.Regist_time,
        //        Check_time = h.Check_time,
        //        Change_time = h.Change_time,
        //        Lastly_change_time = h.Lastly_change_time,
        //        Delete_time = h.Delete_time,
        //        Recovery_time = h.Recovery_time,
        //        Human_file_status = h.Human_file_status
        //    };
        //    return Edit(hf);
        //}

        public Human_file_Model SelByID0(string id)
        {
            List<Human_file> aa = coreDbContext.Human_files.Where( e=> e.Human_id==id).ToList();
            Human_file_Model bb = new Human_file_Model() {
                Human_id = aa[0].Human_id,
                Attachment_name = aa[0].Attachment_name,
                Bonus_amount = aa[0].Bonus_amount,
                Changer = aa[0].Changer,
                Change_time = aa[0].Change_time,
                Checker = aa[0].Checker,
                Check_status = aa[0].Check_status,
                Check_time = aa[0].Check_time,
                Delete_time = aa[0].Delete_time,
                Demand_salaray_sum = aa[0].Demand_salaray_sum,
                File_chang_amount = aa[0].File_chang_amount,
                First_kind_id = aa[0].First_kind_id,
                First_kind_name = aa[0].First_kind_name,
                Huf_id = aa[0].Huf_id,
                Human_account = aa[0].Human_account,
                Human_address = aa[0].Human_address,
                Human_age = aa[0].Human_age,
                Human_bank = aa[0].Human_bank,
                Human_birthday = aa[0].Human_birthday,
                Human_birthplace = aa[0].Human_birthplace,
                Human_educated_degree = aa[0].Human_educated_degree,
                Human_educated_major = aa[0].Human_educated_major,
                Human_educated_years = aa[0].Human_educated_years,
                Human_email = aa[0].Human_email,
                Human_family_membership = aa[0].Human_family_membership,
                Human_file_status = aa[0].Human_file_status,
                Human_histroy_records = aa[0].Human_histroy_records,
                Human_hobby = aa[0].Human_hobby,
                Human_id_card = aa[0].Human_id_card,
                Human_major_id = aa[0].Human_major_id,
                Human_major_kind_id = aa[0].Human_major_kind_id,
                Human_major_kind_name = aa[0].Human_major_kind_name,
                Human_mobilephone = aa[0].Human_mobilephone,
                Human_name = aa[0].Human_name,
                Human_nationality = aa[0].Human_nationality,
                Human_party = aa[0].Human_party,
                Human_picture = aa[0].Human_picture,
                Human_postcode = aa[0].Human_postcode,
                Human_pro_designation = aa[0].Human_pro_designation,
                Human_qq = aa[0].Human_qq,
                Human_race = aa[0].Human_race,
                Human_religion = aa[0].Human_religion,
                Human_sex = aa[0].Human_sex,
                Human_society_security_id = aa[0].Human_society_security_id,
                Human_speciality = aa[0].Human_speciality,
                Human_telephone = aa[0].Human_telephone,
                Hunma_major_name = aa[0].Hunma_major_name,
                Lastly_change_time = aa[0].Lastly_change_time,
                Major_change_amount = aa[0].Major_change_amount,
                Paid_salary_sum = aa[0].Paid_salary_sum,
                Recovery_time = aa[0].Recovery_time,
                Register = aa[0].Register,
                Regist_time = aa[0].Regist_time,
                Remark = aa[0].Remark,
                Salary_standard_id = aa[0].Salary_standard_id,
                Salary_standard_name = aa[0].Salary_standard_name,
                Salary_sum = aa[0].Salary_sum,
                Second_kind_id = aa[0].Second_kind_id,
                Second_kind_name = aa[0].Second_kind_name,
                Third_kind_id = aa[0].Third_kind_id,
                Third_kind_name = aa[0].Third_kind_name,
                Training_amount = aa[0].Training_amount
            };
            return bb;
        }

        public async Task<Human_file_Model> SelByID02(int id)
        {
            Human_file item = await coreDbContext.Human_files.FindAsync(id);
            Human_file_Model a = new Human_file_Model()
            {
                Huf_id = item.Huf_id,
                Attachment_name = item.Attachment_name,
                Bonus_amount = item.Bonus_amount,
                Changer = item.Changer,
                Change_time = item.Change_time,
                Checker = item.Checker,
                Check_status = item.Check_status,
                Check_time = item.Check_time,
                Delete_time = item.Delete_time,
                Demand_salaray_sum = item.Demand_salaray_sum,
                File_chang_amount = item.File_chang_amount,
                First_kind_id = item.First_kind_id,
                First_kind_name = item.First_kind_name,
                Human_account = item.Human_account,
                Human_address = item.Human_address,
                Human_age = item.Human_age,
                Human_bank = item.Human_bank,
                Human_birthday = item.Human_birthday,
                Human_birthplace = item.Human_birthplace,
                Human_educated_degree = item.Human_educated_degree,
                Human_educated_major = item.Human_educated_major,
                Human_educated_years = item.Human_educated_years,
                Human_email = item.Human_email,
                Human_family_membership = item.Human_family_membership,
                Human_file_status = item.Human_file_status,
                Human_histroy_records = item.Human_histroy_records,
                Human_hobby = item.Human_hobby,
                Human_id = item.Human_id,
                Human_id_card = item.Human_id_card,
                Human_major_id = item.Human_major_id,
                Human_major_kind_id = item.Human_major_kind_id,
                Human_major_kind_name = item.Human_major_kind_name,
                Human_mobilephone = item.Human_mobilephone,
                Human_name = item.Human_name,
                Human_nationality = item.Human_nationality,
                Human_party = item.Human_party,
                Human_picture = item.Human_picture,
                Human_postcode = item.Human_postcode,
                Human_pro_designation = item.Human_pro_designation,
                Human_qq = item.Human_qq,
                Human_race = item.Human_race,
                Human_religion = item.Human_religion,
                Human_sex = item.Human_sex,
                Human_society_security_id = item.Human_society_security_id,
                Human_speciality = item.Human_speciality,
                Human_telephone = item.Human_telephone,
                Hunma_major_name = item.Hunma_major_name,
                Lastly_change_time = item.Lastly_change_time,
                Major_change_amount = item.Major_change_amount,
                Paid_salary_sum = item.Paid_salary_sum,
                Recovery_time = item.Recovery_time,
                Register = item.Register,
                Regist_time = item.Regist_time,
                Remark = item.Remark,
                Salary_standard_id = item.Salary_standard_id,
                Salary_standard_name = item.Salary_standard_name,
                Salary_sum = item.Salary_sum,
                Second_kind_id = item.Second_kind_id,
                Second_kind_name = item.Second_kind_name,
                Third_kind_id = item.Third_kind_id,
                Third_kind_name = item.Third_kind_name,
                Training_amount = item.Training_amount,
            };
            return a;
        }

        public async Task<int> Up(Human_file_Model h)
        {
            Human_file hf = new Human_file
            {
                Huf_id = h.Huf_id,
                Human_id = h.Human_id,
                First_kind_id = h.First_kind_id,
                First_kind_name = h.First_kind_name,
                Second_kind_id = h.Second_kind_id,
                Second_kind_name = h.Second_kind_name,
                Third_kind_id = h.Third_kind_id,
                Third_kind_name = h.Third_kind_name,
                Human_name = h.Human_name,
                Human_address = h.Human_address,
                Human_postcode = h.Human_postcode,
                Human_pro_designation = h.Human_pro_designation,
                Human_major_kind_id = h.Human_major_kind_id,
                Human_major_kind_name = h.Human_major_kind_name,
                Human_major_id = h.Human_major_id,
                Hunma_major_name = h.Hunma_major_name,
                Human_telephone = h.Human_telephone,
                Human_mobilephone = h.Human_mobilephone,
                Human_bank = h.Human_bank,
                Human_account = h.Human_account,
                Human_qq = h.Human_qq,
                Human_email = h.Human_email,
                Human_hobby = h.Human_hobby,
                Human_speciality = h.Human_speciality,
                Human_sex = h.Human_sex,
                Human_religion = h.Human_religion,
                Human_party = h.Human_party,
                Human_nationality = h.Human_nationality,
                Human_race = h.Human_race,
                Human_birthday = h.Human_birthday,
                Human_birthplace = h.Human_birthplace,
                Human_age = h.Human_age,
                Human_educated_degree = h.Human_educated_degree,
                Human_educated_years = h.Human_educated_years,
                Human_educated_major = h.Human_educated_major,
                Human_society_security_id = h.Human_society_security_id,
                Human_id_card = h.Human_id_card,
                Remark = h.Remark,
                Salary_standard_id = h.Salary_standard_id,
                Salary_standard_name = h.Salary_standard_name,
                Salary_sum = h.Salary_sum,
                Demand_salaray_sum = h.Demand_salaray_sum,
                Paid_salary_sum = h.Paid_salary_sum,
                Major_change_amount = h.Major_change_amount,
                Bonus_amount = h.Bonus_amount,
                Training_amount = h.Training_amount,
                File_chang_amount = h.File_chang_amount,
                Human_histroy_records = h.Human_histroy_records,
                Human_family_membership = h.Human_family_membership,
                Human_picture = h.Human_picture,
                Attachment_name = h.Attachment_name,
                Check_status = h.Check_status,
                Register = h.Register,
                Checker = h.Checker,
                Changer = h.Changer,
                Regist_time = h.Regist_time,
                Check_time = h.Check_time,
                Change_time = h.Change_time,
                Lastly_change_time = h.Lastly_change_time,
                Delete_time = h.Delete_time,
                Recovery_time = h.Recovery_time,
                Human_file_status = h.Human_file_status
            };
            coreDbContext.Human_files.Update(hf);
            return await coreDbContext.SaveChangesAsync();
        }
    }
}
