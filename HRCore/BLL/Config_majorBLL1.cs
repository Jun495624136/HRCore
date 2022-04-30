using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;

namespace BLL
{
    public class Config_majorBLL1 : IConfig_majorBLL1
    {
        private readonly IConfig_majorDAO1 sdao;
        public Config_majorBLL1(IConfig_majorDAO1 sdao)
        {
            this.sdao = sdao;
        }
        public List<Config_major_Model> SelectsMajor()
        {
            return sdao.SelectsMajor();
        }
    }
}
