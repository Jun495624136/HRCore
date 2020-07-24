using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;
using System.Threading.Tasks;

namespace BLL
{
    public class Config_file_first_kindBLL : IConfig_file_first_kindBLL
    {
        private readonly IConfig_file_first_kindDAO sdao;
        public Config_file_first_kindBLL(IConfig_file_first_kindDAO sdao)
        {
            this.sdao = sdao;
        }
        public List<Config_file_first_kind_Model> SelectFirst()
        {
            return sdao.SelectFirst();
        }
    }
}
