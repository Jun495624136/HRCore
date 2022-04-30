using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class config_major_kindDAO3:config_major_kindIDAO3
    {
        private readonly HR_DBContext coreDbContext;
        public config_major_kindDAO3(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_major_kind_Model> config_majorSelect()
        {
            List<Config_major_kind> list = coreDbContext.Config_major_kinds.ToList();
            List<Config_major_kind_Model> list2 = new List<Config_major_kind_Model>();
            foreach (Config_major_kind item in list)
            {
                Config_major_kind_Model moedl = new Config_major_kind_Model()
                {
                    Mfk_id = item.Mfk_id,
                    Major_kind_id = item.Major_kind_id,
                    Major_kind_name = item.Major_kind_name
                };
                list2.Add(moedl);
            }
            return list2;
        }
    }
}
