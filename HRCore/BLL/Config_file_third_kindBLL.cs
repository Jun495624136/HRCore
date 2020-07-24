using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;

namespace BLL
{
    public class Config_file_third_kindBLL : IConfig_file_third_kindBLL
    {
        private readonly IConfig_file_third_kindDAO sdao;
        public Config_file_third_kindBLL(IConfig_file_third_kindDAO sdao)
        {
            this.sdao = sdao;
        }
        public List<Config_file_third_kind_Model> SelectThird()
        {
            return sdao.SelectThird();
        }
    }
}
