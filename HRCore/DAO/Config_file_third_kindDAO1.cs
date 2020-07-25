using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class Config_file_third_kindDAO1 : IConfig_file_third_kindDAO1
    {
        private readonly HR_DBContext hR_DBContext;
        public Config_file_third_kindDAO1(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }
        public List<Config_file_third_kind_Model> SelectThird()
        {
            var list = hR_DBContext.Config_file_third_kinds.ToList();
            List<Config_file_third_kind_Model> list2 = new List<Config_file_third_kind_Model>();

            foreach (var item in list)
            {
                Config_file_third_kind_Model cftk = new Config_file_third_kind_Model()
                {
                   Ftk_id=item.Ftk_id,
                   First_kind_id=item.First_kind_id,
                   First_kind_name=item.First_kind_name,
                   Second_kind_id=item.Second_kind_id,
                   Second_kind_name=item.Second_kind_name,
                   Third_kind_id=item.Third_kind_id,
                   Third_kind_name=item.Third_kind_name,
                   Third_kind_is_retail=item.Third_kind_is_retail,
                   Third_kind_sale_id=item.Third_kind_sale_id,
                };
                list2.Add(cftk);
            }
            return list2;
        }
    }
}
