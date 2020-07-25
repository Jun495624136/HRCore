using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;
using System.Threading.Tasks;

namespace BLL
{
    public class Config_file_first_kindBLL1 : IConfig_file_first_kindBLL1
    {
        private readonly IConfig_file_first_kindDAO1 sdao;
        public Config_file_first_kindBLL1(IConfig_file_first_kindDAO1 sdao)
        {
            this.sdao = sdao;
        }
        public List<Config_file_first_kind_Model> SelectFirst()
        {
            return sdao.SelectFirst();
        }
    }
}
