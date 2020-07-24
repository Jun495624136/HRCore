using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;

namespace BLL
{
    public class Config_majorBLL : IConfig_majorBLL
    {
        private readonly IConfig_majorDAO sdao;
        public Config_majorBLL(IConfig_majorDAO sdao)
        {
            this.sdao = sdao;
        }
        public List<Config_major_Model> SelectsMajor()
        {
            return sdao.SelectsMajor();
        }
    }
}
