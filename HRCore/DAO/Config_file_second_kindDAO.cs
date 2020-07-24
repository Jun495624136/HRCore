using System;
using System.Collections.Generic;
using System.Text;
using EFEntity;
using Model;
using IDAO;
using System.Linq;

namespace DAO
{
    public class Config_file_second_kindDAO : Config_file_second_kindIDAO
    {
        private readonly HR_DBContext coreDbContext;
        public Config_file_second_kindDAO(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }
        public List<Config_file_second_kind_Model> EJselect()
        {
            List<Config_file_second_kind_Model> list2 = new List<Config_file_second_kind_Model>();
            List<Config_file_second_kind> list = coreDbContext.Config_file_second_kinds.ToList();
            foreach (Config_file_second_kind item in list)
            {
                Config_file_second_kind_Model tm = new Config_file_second_kind_Model
                {
                    First_kind_id = item.First_kind_id,
                    First_kind_name = item.First_kind_name,
                    Fsk_id = item.Fsk_id,
                    Second_kind_id = item.Second_kind_id,
                    Second_kind_name = item.Second_kind_name,
                    Second_salary_id = item.Second_salary_id,
                    Second_sale_id = item.Second_sale_id
                };
                list2.Add(tm);
            }
            return list2;
        }
    }
}
