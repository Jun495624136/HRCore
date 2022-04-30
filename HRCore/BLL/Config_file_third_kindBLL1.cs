using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;

namespace BLL
{
    public class Config_file_third_kindBLL1 : IConfig_file_third_kindBLL1
    {
        private readonly IConfig_file_third_kindDAO1 sdao;
        public Config_file_third_kindBLL1(IConfig_file_third_kindDAO1 sdao)
        {
            this.sdao = sdao;
        }
        public List<Config_file_third_kind_Model> SelectThird()
        {
            return sdao.SelectThird();
        }
    }
}
