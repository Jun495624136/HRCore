using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class Config_major_kindDAO1 : IConfig_major_kindDAO1
    {
        private readonly HR_DBContext hR_DBContext;
        public Config_major_kindDAO1(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }
        public List<Config_major_kind_Model> SelectMakind()
        {
            var list = hR_DBContext.Config_major_kinds.ToList();
            List<Config_major_kind_Model> list2 = new List<Config_major_kind_Model>();
            foreach (var item in list)
            {
                Config_major_kind_Model cfk = new Config_major_kind_Model()
                {                    
                    Mfk_id = item.Mfk_id,
                    Major_kind_id = item.Major_kind_id,
                    Major_kind_name = item.Major_kind_name
                };
                list2.Add(cfk);
            }
            return list2;
        }
    }
}
