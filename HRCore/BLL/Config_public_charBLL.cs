using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IBLL;
using System.Threading.Tasks;
using IDAO;
namespace BLL
{
    public class Config_public_charBLL : IConfig_public_charBLL
    {
        private readonly IConfig_public_charDAO cdao;
        public Config_public_charBLL(IConfig_public_charDAO cdao)
        {
            this.cdao = cdao;
        }

        public Task<int> GetConfigPublicCharDel(int id)
        {
            return cdao.GetConfigPublicCharDel(id);
        }

        public Task<List<Config_public_char_Model>> GetConfigPublicCharSelect()
        {
            return cdao.GetConfigPublicCharSelect();
        }
    }
}
