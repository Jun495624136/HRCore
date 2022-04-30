using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class Config_majorDAO3:Config_majorIDAO3
    {
        private readonly HR_DBContext coreDbContext;
        public Config_majorDAO3(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_major_Model> config_majorSelect()
        {
            List<Config_major> list = coreDbContext.Config_majors.ToList();
            List<Config_major_Model> list2 = new List<Config_major_Model>();
            foreach (Config_major item in list)
            {
                Config_major_Model model = new Config_major_Model()
                {
                    Mak_id = item.Mak_id,
                    Major_kind_id = item.Major_kind_id,
                    Major_kind_name = item.Major_kind_name,
                    Major_id = item.Major_id,
                    Major_name = item.Major_name,
                    Test_amount = item.Test_amount
                };
                list2.Add(model);
            }
            return list2;
        }
    }
}
