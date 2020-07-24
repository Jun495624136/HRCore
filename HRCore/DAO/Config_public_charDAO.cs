using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Threading.Tasks;
using System.Linq;

namespace DAO
{
    public class Config_public_charDAO : IConfig_public_charDAO
    {
        private readonly HR_DBContext dbContext;
        public Config_public_charDAO(HR_DBContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<int> GetConfigPublicCharDel(int id)
        {
            Config_public_char config_ = await dbContext.Config_public_chars.FindAsync(id);
            dbContext.Config_public_chars.Remove(config_);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<List<Config_public_char_Model>> GetConfigPublicCharSelect()
        {
            var list =  dbContext.Config_public_chars.ToList();
            List<Config_public_char_Model> list2 = new List<Config_public_char_Model>();
            var result = await Task.Run(() =>
            {
                foreach (var item in list)
                {
                    Config_public_char_Model cm = new Config_public_char_Model() 
                    {
                        Pbc_id=item.Pbc_id,
                        Attribute_kind = item.Attribute_kind,
                        Attribute_name = item.Attribute_name
                    };
                    list2.Add(cm);
                }
                return list2;
            });
            return result;
        }
    }
}
