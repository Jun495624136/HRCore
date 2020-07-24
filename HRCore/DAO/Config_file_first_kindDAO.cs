using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using EFEntity;

using System.Linq;

namespace DAO
{
    public class Config_file_first_kindDAO : IConfig_file_first_kindDAO
    {
        private readonly HR_DBContext hR_DBContext;
        public Config_file_first_kindDAO(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }
        public List<Config_file_first_kind_Model> SelectFirst()
        {
            var list = hR_DBContext.Config_file_first_kinds.ToList();
            List<Config_file_first_kind_Model> list2 = new List<Config_file_first_kind_Model>();
          
                foreach (var item in list)
                {
                    Config_file_first_kind_Model cffk = new Config_file_first_kind_Model()
                    {
                       Ffk_id=item.Ffk_id,
                       First_kind_id=item.First_kind_id,
                       First_kind_name=item.First_kind_name,
                       First_kind_salary_id=item.First_kind_salary_id,
                       First_kind_sale_id=item.First_kind_sale_id,
                    };
                    list2.Add(cffk);
                }
                return list2;
           
        }

     
    }
}
