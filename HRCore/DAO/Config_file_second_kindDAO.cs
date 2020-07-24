using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class Config_file_second_kindDAO : IConfig_file_second_kindDAO
    {
        private readonly HR_DBContext hR_DBContext;
        public Config_file_second_kindDAO(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }

        public List<Config_file_second_kind_Model> SelectSecond()
        {
            var list = hR_DBContext.Config_file_second_kinds.ToList();
            List<Config_file_second_kind_Model> list2 = new List<Config_file_second_kind_Model>();
         
                foreach (var item in list)
                {
                    Config_file_second_kind_Model cffk = new Config_file_second_kind_Model()
                    {
                     Fsk_id=item.Fsk_id,
                     First_kind_id=item.First_kind_id,
                     First_kind_name=item.First_kind_name,
                     Second_kind_id=item.Second_kind_id,
                     Second_kind_name=item.Second_kind_name,
                     Second_salary_id=item.Second_salary_id,
                     Second_sale_id=item.Second_sale_id
                    };
                    list2.Add(cffk);
                }
                return list2;
           
        }
    }
}
