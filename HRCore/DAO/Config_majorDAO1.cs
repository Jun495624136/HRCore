using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class Config_majorDAO1 : IConfig_majorDAO1
    {
        private readonly HR_DBContext hR_DBContext;
        public Config_majorDAO1(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }
        public List<Config_major_Model> SelectsMajor()
        {
            var list = hR_DBContext.Config_majors.ToList();
            List<Config_major_Model> list2 = new List<Config_major_Model>();
            foreach (var item in list)
            {
                Config_major_Model cmm = new Config_major_Model()
                {
                    Mak_id = item.Mak_id,
                    Major_id=item.Major_id,
                    Major_name=item.Major_name,
                    Major_kind_id = item.Major_kind_id,
                    Major_kind_name = item.Major_kind_name,
                    Test_amount=item.Test_amount                    
                };
                list2.Add(cmm);
            }
            return list2;
        }
    }
}
