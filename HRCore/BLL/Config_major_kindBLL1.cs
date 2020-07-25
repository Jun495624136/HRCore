using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;

namespace BLL
{
    public class Config_major_kindBLL1 : IConfig_major_kindBLL1
    {
        private readonly IConfig_major_kindDAO1 sdao;
        public Config_major_kindBLL1(IConfig_major_kindDAO1 sdao)
        {
            this.sdao = sdao;
        }
        public List<Config_major_kind_Model> SelectMakind()
        {
            return sdao.SelectMakind();
        }
    }
}
