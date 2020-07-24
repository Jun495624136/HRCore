using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;
namespace BLL
{
    public class Config_majorBLL:Config_majorIBLL
    {
        private readonly Config_majorIDAO coreDbContext;
        public Config_majorBLL(Config_majorIDAO coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_major_Model> config_majorSelect()
        {
            return coreDbContext.config_majorSelect();
        }
    }
}
