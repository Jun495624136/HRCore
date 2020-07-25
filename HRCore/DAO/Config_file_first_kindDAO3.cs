using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using EFEntity;
using Model;
using System.Threading.Tasks;
using System.Linq;

namespace DAO
{
    public class Config_file_first_kindDAO3:Config_file_first_kindIDAO3
    {
        private readonly HR_DBContext coreDbContext;
        public Config_file_first_kindDAO3(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public  List<Config_file_first_kind_Model> YJselect()
        {
            List<Config_file_first_kind_Model> list2 = new List<Config_file_first_kind_Model>();
            List<Config_file_first_kind> list =  coreDbContext.Config_file_first_kinds.ToList();
            foreach (Config_file_first_kind item in list)
            {
                Config_file_first_kind_Model tm = new Config_file_first_kind_Model()
                {
                    First_kind_id = item.First_kind_id,
                    First_kind_name = item.First_kind_name,
                    Ffk_id = item.Ffk_id,
                    First_kind_salary_id = item.First_kind_salary_id,
                    First_kind_sale_id = item.First_kind_sale_id
                };
                 list2.Add(tm);
            }
            return  list2;
        }
    }
}
