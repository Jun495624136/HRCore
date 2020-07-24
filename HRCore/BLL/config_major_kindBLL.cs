using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IBLL;
using IDAO;
namespace BLL
{
     public class config_major_kindBLL:config_major_kindIBLL
    {
        private readonly config_major_kindIDAO coreDbContext;
        public config_major_kindBLL(config_major_kindIDAO coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_major_kind_Model> config_majorSelect()
        {
            return coreDbContext.config_majorSelect();
        }
    }
}
