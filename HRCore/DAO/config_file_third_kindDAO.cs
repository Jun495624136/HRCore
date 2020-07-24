using System;
using System.Collections.Generic;
using System.Text;
using Model;
using EFEntity;
using IDAO;
using System.Linq;

namespace DAO
{
    public class config_file_third_kindDAO:config_file_third_kindIDAO
    {
        private readonly HR_DBContext coreDbContext;
        public config_file_third_kindDAO(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_file_third_kind_Model> SJselect()
        {
            List<Config_file_third_kind_Model> list2 = new List<Config_file_third_kind_Model>();
            List<Config_file_third_kind> list = coreDbContext.Config_file_third_kinds.ToList();
            foreach (Config_file_third_kind item in list)
            {
                Config_file_third_kind_Model tm = new Config_file_third_kind_Model()
                {
                    First_kind_id = item.First_kind_id,
                    First_kind_name = item.First_kind_name,
                    Ftk_id = item.Ftk_id,
                    Second_kind_id = item.Second_kind_id,
                    Second_kind_name = item.Second_kind_name,
                    Third_kind_id = item.Third_kind_id,
                    Third_kind_is_retail = item.Third_kind_is_retail,
                    Third_kind_name = item.Third_kind_name,
                    Third_kind_sale_id = item.Third_kind_sale_id

                };
                list2.Add(tm);
            }
            return list2;
        }
    }
}
