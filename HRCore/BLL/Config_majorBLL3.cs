using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;
namespace BLL
{
    public class Config_majorBLL3:Config_majorIBLL3
    {
        private readonly Config_majorIDAO3 coreDbContext;
        public Config_majorBLL3(Config_majorIDAO3 coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_major_Model> config_majorSelect()
        {
            return coreDbContext.config_majorSelect();
        }
    }
}
