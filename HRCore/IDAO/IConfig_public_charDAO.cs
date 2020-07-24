using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
    public interface IConfig_public_charDAO
    {
        Task<List<Config_public_char_Model>> GetConfigPublicCharSelect();

        Task<int> GetConfigPublicCharDel(int id);
    }
}
