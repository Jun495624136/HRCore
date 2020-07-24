using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Linq;

namespace DAO
{
   public class Config_public_charDAO:IConfig_public_charDAO
    {
        private readonly HR_DBContext hR_DBContext;
        public Config_public_charDAO(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }

        public List<Config_public_char_Model> SelectChar()
        {
            var list = hR_DBContext.Config_public_chars.ToList();
            List<Config_public_char_Model> list2 = new List<Config_public_char_Model>();

            foreach (var item in list)
            {
                Config_public_char_Model cpc = new Config_public_char_Model()
                {
                    Pbc_id = item.Pbc_id,
                    Attribute_kind = item.Attribute_kind,
                    Attribute_name = item.Attribute_name
                };
                list2.Add(cpc);
            }
            return list2;
        }
    }
}
