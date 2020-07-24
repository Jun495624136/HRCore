using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IConfig_public_charBLL
    {
        Task<List<Config_public_char_Model>> GetConfigPublicCharSelect();
        Task<int> GetConfigPublicCharDel(int id);
    }
}
