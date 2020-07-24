using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;

namespace BLL
{
    public class Config_major_kindBLL : IConfig_major_kindBLL
    {
        private readonly IConfig_major_kindDAO sdao;
        public Config_major_kindBLL(IConfig_major_kindDAO sdao)
        {
            this.sdao = sdao;
        }
        public List<Config_major_kind_Model> SelectMakind()
        {
            return sdao.SelectMakind();
        }
    }
}
