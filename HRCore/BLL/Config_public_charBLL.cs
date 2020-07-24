using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using IBLL;
using Model;

namespace BLL
{
   public class Config_public_charBLL:IConfig_public_charBLL
    {
        private readonly IConfig_public_charDAO sdao;
        public Config_public_charBLL(IConfig_public_charDAO sdao)
        {
            this.sdao = sdao;
        }

        public List<Config_public_char_Model> SelectChar()
        {
            return sdao.SelectChar();
        }
    }
}
